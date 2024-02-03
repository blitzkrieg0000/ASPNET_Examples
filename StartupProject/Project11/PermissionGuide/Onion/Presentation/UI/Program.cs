using System.Globalization;
using System.Security.Claims;
using System.Text;
using Application;
using Application.Consts.Auth;
using Infrastructure;
using Infrastructure.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Persistence;
using StackExchange.Redis;
using UI.Behaviors;
using UI.Extension;


internal class Program {

    private static readonly object _multiplexerLock = new(); // Lock object
    private static ConnectionMultiplexer? multiplexer;       // Redis sunucularına bağlantıların birbiriyle ilişkili bir grubunu temsil eder. Buna bir referans tutulmalı ve yeniden kullanılmalıdır.


	private static void Main(string[] args) {

		//! BUILDER----------------------------------------------------------------------------------------------------
		var builder = WebApplication.CreateBuilder(args);
		#region Builder

		#region Forwarded Headers
		builder.Services.Configure<ForwardedHeadersOptions>(options => {
			// Load balancer gibi yapılar kullanırken dışarıdan gelen istekteki Headerları kaybetmemek için bu ayar gereklidir. Öyleymiş Network Mühendisi Değilim
			options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
		});
		#endregion


		#region Add Environment Variables 
		/*
			Uygulamayı publish ettiğimizde -sırasıyla- nerelerden ortam değişkeni okuyacağınızı belirlersiniz. 1-appsettings.json, 2-Ortam değişkenleri
		*/
		if (builder.Environment.IsDevelopment()) {
			builder.Configuration.AddJsonFile("appsettings.Development.json", false, true);
			Console.WriteLine("Development Settings Activated");
		}
		else {
			builder.Configuration.AddJsonFile("appsettings.Production.json", false, true);
			Console.WriteLine("Production Settings Activated");
		}
		builder.Configuration.AddEnvironmentVariables(); // "ConnectionStrings__Default" gibi dışarıdan değer alabilmek için ayar
		#endregion


        #region Start Redis ConnectionMultiplexer
        lock (_multiplexerLock) {   // Uygulama başlarken threadlerin sıralı erişmesini sağlar. Çok instance oluşturmasakta thread-safe biçimde ayağa kaldırmak için lockladık.
            multiplexer = ConnectionMultiplexer.Connect(builder.Configuration["Redis:ServerURL"], opt => {
                // opt.ClientName = "SafeRedisConnection";
                opt.ConnectTimeout = 300000;
                opt.SyncTimeout = 300000;
                opt.AbortOnConnectFail = false;
            });
        }
        #endregion


		#region Data Protection Defaults
		var dataProtector = builder.Services.AddDataProtection(opt => opt.ApplicationDiscriminator = "MasterDataProtection")
			.UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration {
				EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
				ValidationAlgorithm = ValidationAlgorithm.HMACSHA512
			}).SetApplicationName("WebAppOnion01")
		.PersistKeysToStackExchangeRedis(multiplexer, "DataProtection-Keys");
		#endregion


		#region Kestrel Settings
		// Request boyutunu belirtir.
		builder.WebHost.ConfigureKestrel(serverOptions => {
			serverOptions.Limits.MaxRequestBodySize = 209715200;
		});
		#endregion


        #region StackExchange Redis Cache
        // Docker gibi ölçeklendirme yaptığımız, server-farmlarda kendi kullandığımız cache'ten farklı olarak, uygulamadaki sessionlar ve diğer in memory objeleri diğer instancelar ile paylaşarak tutarlı bir uygulama ortamı meydana getirir.
        // Dağıtık sistem için gereklidir.
        // Infrastructure'da zaten var olan IConnectionMultiplexer servisi tanımlamıştık. Tekrar tanımlamadan, servislerden alıp, AddStackExchangeRedisCache in kullanabilmesi için verdik.
        builder.Services.AddOptions<RedisCacheOptions>().Configure<IServiceProvider>((options, serviceProvider) => {
            options.ConnectionMultiplexerFactory = () => Task.FromResult(serviceProvider.GetService<IConnectionMultiplexer>());
        });
        builder.Services.AddStackExchangeRedisCache(_ => { });
        #endregion


		#region Controller Settings
		// Contollerlar ile Viewleri kullanmayı aktif ederiz ve option'lar ile Filter yapılanmalarını otomatik olarak tüm controller'ların önüne koymuş oluştururuz.
		builder.Services.AddControllersWithViews(options => {
			// options.Filters.Add<ValidationFilter>();
			// options.Filters.Add<RoleEndpointPermissionFilter>(); //Kullanıcının istek yaptığı endpointe yetkisi yoksa Forbidden sayfasına yönlendirir.
			// options.Filters.Add<ValidationActionFilter>(ValidationActionFilter.LowerOrderThanModelStateInvalidFilter); // FluentValidation'a Async AutoValidation özelliği kazandırır.
		})
		.ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true)  // Varsayılan olarak gelen istekteki obje, controllera düşmeden validation yapılır ve hata varsa geri döndürülür. Bunu davranışı bastırabiliririz.
		.AddSessionStateTempDataProvider();      // Default olarak "CookieBasedTempDataProvider" aktiftir. Gerekli görülürse TempData'nın Session'larda tutulması için çevrilebilir. Özellikle cookie tutulmasını onaylamayan kullanıcılar giriş yaptığından oturum cookie'si tutamıyorsak işimize yarar.
												 // .AddCookieTempDataProvider(opt => {  // Yukarıdaki yorum satırında bahsedilen Default davranış budur.  
												 //     opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
												 // });
		#endregion


		#region Session Settings
		// Session Service
		builder.Services.AddSession(options => {
			options.IdleTimeout = TimeSpan.FromSeconds(1800);
			options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			options.Cookie.Name = "AppCookie.Session";
			options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
			options.Cookie.HttpOnly = true;
			options.Cookie.IsEssential = true;
		});
		#endregion


		#region Cookie Settings
		// Cookie Service
		builder.Services.ConfigureApplicationCookie(opt => {
			opt.Cookie.HttpOnly = true;
			opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
			opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			opt.Cookie.Name = "AppCookie";
			opt.ExpireTimeSpan = TimeSpan.FromDays(1);
			// opt.LoginPath = new PathString("/Home/SignIn");
			// opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
		});
		#endregion


		#region Authentication Settings
		// Authentication (JWT - COOKIE)
		builder.Services.AddAuthentication(opt => {
		    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		})
		.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt => {
		    /*
		        MVC Web girişleri için authentication yönetimi
		    */
		    opt.Cookie.Name = "CustomAuthCookie";
		    opt.Cookie.IsEssential = true;
		    opt.Cookie.HttpOnly = true;
		    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
		    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
		    opt.ExpireTimeSpan = TimeSpan.FromSeconds(double.Parse(builder.Configuration["AuthCookie:ExpireTimeSeconds"]));
		    opt.LoginPath = new PathString("/Auth/SignIn");
		    opt.LogoutPath = new PathString("/Auth/LogOut");
		    opt.AccessDeniedPath = new PathString("/Auth/AccessDenied");
		})
		.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt => {
		    /*
		        API Girişleri için authentication yönetimi
		    */
		    opt.RequireHttpsMetadata = false; //true
		    opt.TokenValidationParameters = new() {
		        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 },
		        ValidateAudience = true,
		        ValidateIssuer = true,
		        ValidateLifetime = true,
		        ValidateIssuerSigningKey = true,
		        ValidIssuer = builder.Configuration["Bearer:Issuer"],
		        ValidAudience = builder.Configuration["Bearer:Audience"],
		        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Bearer:Key"])), // min 16 char
		        ClockSkew = TimeSpan.Zero,
		        NameClaimType = ClaimTypes.Name,
		        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow
		    };
		})
		.AddPolicyScheme("JWT", "JWT", options => {
		    options.ForwardDefaultSelector = context => {
		        // Eğer [Authorize(AuthenticationSchemes = "JWT")] attribute'u ile JWT kontrolü yapılacağı belirtilmişse,
		        // kullanıcıdan gelen request'in header'ı kontroler edilir ve "Bearer <Token>" ifadesi aranır.
		        // MVC uygulamalarında ise View yapısı kullandığımızdan, kullanıcının JWT token'ini Cookielerden okuyup 
		        // kendimiz header'a ekleriz ve kontrole göndeririz.
		        var jwt = context.User.Claims.FirstOrDefault(x => x.Type == "jwtToken")?.Value;

		        if (jwt != null) {
		            context.Request.Headers.Authorization = "Bearer " + jwt;
		        }

		        // Request'in header'ında JWT token aranır.
		        string? authorization = context.Request.Headers[HeaderNames.Authorization];
		        if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer ")) {
		            return JwtBearerDefaults.AuthenticationScheme;
		        }

		        context.Response.Redirect("Auth/LogOut");
		        return CookieAuthenticationDefaults.AuthenticationScheme;
		    };
		});
		#endregion


		#region Authorization Settings
		// TODO Top-Statementa çevrilebilir: ASP0025
		builder.Services.AddAuthorization(opt => {
			// Statik rol gruplarını belirlemeyi sağlar. 
			opt.AddPolicy(RoleGroupDefaults.AdminGroup,
			policy => {
				policy.RequireRole(RoleDefaults.SuperUser.Name, RoleDefaults.Admin.Name); // Rol gruplarından en az bir role sahip kullanıcı bu rol grubu içinde sayılır.
			});

			opt.AddPolicy(RoleGroupDefaults.MemberGroup,
			policy => {
				policy.RequireRole(RoleDefaults.Member.Name);
			});
		});
		#endregion


		#region CORS Settings
		builder.Services.AddCors(cors => {
			cors.AddPolicy("WebApiPolicy", opt => {
				opt.WithOrigins("https://localhost", builder.Configuration["Host:Domain"], "https://accounts.google.com").AllowAnyHeader().AllowAnyMethod();
			});
		});
		#endregion


		#region CookiePolicy-KVKK Settings
		//! GDPR - KVKK
		builder.Services.Configure<CookiePolicyOptions>(options => {
			//Bu lambda, kullanıcının zorunlu olmayan işlemler için onay verip vermediğini belirler.
			//belirli bir istek için tanımlama bilgileri gereklidir.
			options.CheckConsentNeeded = context => true;
			options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
			//! Endpointlerdeki cookie-session bilgilerini özel olarak bu şekilde manipüle edebiliriz. Örneğin Lax kullanım yapabiliriz.
			// options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
			// options.OnAppendCookie = cookieContext => {
			//     var route = cookieContext.Context.Request.RouteValues;
			//     if (route["Action"] is not null and (object?)"GoogleLoginAuth") {
			//         cookieContext.CookieOptions.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
			//         cookieContext.CookieOptions.Secure = true;
			//         cookieContext.CookieOptions.IsEssential = true;
			//     }
			// };

		});
		#endregion


		#region Registration Services
		builder.Services.AddApplicationServices();
		builder.Services.AddInfrastructureServices(multiplexer);
		builder.Services.AddPersistenceServices(builder.Configuration);
		builder.Services.AddStorage(StorageType.Local);
		#endregion

        #region ContextAccessor
        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        #endregion


        #region Behavior
        // IMediator'a gönderilen requestleri tutmak için gerekli bir interceptor davranış paterni
        // Global hata yanıtları gibi durumlarda kullanmak üzere ayarlandı. Gerekli olursa kullanıalcak.
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        #endregion


		#region Compression
		builder.Services.AddResponseCompression(options => {
			options.EnableForHttps = true;
			options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
				new[] { "image/svg+xml", "image/png", "image/jpeg", "application/javascript", "text/css" }
			);
		});
		#endregion

		#region IMemoryCache Service
		builder.Services.AddMemoryCache();
		#endregion

		//// Builder
		#endregion


		//! APPLICATION------------------------------------------------------------------------------------------------
		var app = builder.Build();
		#region Application

		// Dinamik olarak http responseları sıkıştırmak için middleware ekler.
		app.UseResponseCompression();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment()) {
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		//Exception Handler
		app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");

		// NotFound sayfasının konumunu ayarlar.
		app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


		// Enforce Https
		app.UseHttpsRedirection();

		//Forwarders Headers
		app.UseForwardedHeaders();

		// // HTTP request ve response'larını log'a kaydedebilen bir middleware ekler.
		// app.UseHttpLogging();

		// Dışarıya açılan dosya tipinin hangi content ile gönderileceği belirlenir. (application/x-www-form-urlencoded, text/plain vs...)
		var contextTypeProvider = new FileExtensionContentTypeProvider();
		contextTypeProvider.Mappings[".js"] = "application/javascript";

		// wwwroot klasörünü erişime açar.
		app.UseStaticFiles(new StaticFileOptions() {
			ContentTypeProvider = contextTypeProvider,
			// OnPrepareResponse = ctx => { // Browser'a cache'i ne kadar tutacağını söyler. Statik dosyalar için önemlidir.
			//     ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
			//     ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
			// }
		});

		// node_modules klasörünü erişime açar.
		app.UseStaticFiles(new StaticFileOptions() {
			ContentTypeProvider = contextTypeProvider,
			FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
			RequestPath = "/node_modules",
			OnPrepareResponse = ctx => { // Browser'a cache'i ne kadar tutacağını söyler. Statik dosyalar için önemlidir.
				ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
				ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
			}
		});

		// GDPR - KVKK (Çerezleri kabul ediyor musunuz ? CookiePolicy.cshtml => "Hassas verilerinizi çerezlerde tutmuyoruz vs.")
		app.UseCookiePolicy();

		// Yönlendirme katmanı eklemek için middleware.
		app.UseRouting();

		// CORS : Bilinmeyen/Saldırgan sitelerden gelen isteklerin reddi için
		app.UseCors("WebApiPolicy");

		// Cookie ve Session kullanabilmek için gerekli etkinleştirme.
		app.UseSession();

		// Kimlik doğrulama protokollerini etkinleştirir.
		app.UseAuthentication();

		// Yetkilendirme protokollerini etkinleştirir.
		app.UseAuthorization();

		//* Custom Middleware
		// app.UseMiddleware<RequestEditingMiddleware>();

		// Sayfa ve URL arasındaki mapping-routing işlemleri
		//* Her bir routing için manuel olarak:
		// app.MapGet("/", () => "Hello World!");

		//* Tüm sayfalar için endpoint kullanarak belirli bir patern ile:

		//* Bunun yerine aşağıda top-level statement kullandık. 
		// app.UseEndpoints(endpoints => {
		//     endpoints.MapControllerRoute(
		//         name: "default",
		//         pattern: "{Controller}/{Action}/{id?}",
		//         defaults: new { Controller = "Home", Action = "Index" }
		//     );
		// });

		app.MapControllerRoute(
			name: "default",
			pattern: "{Controller}/{Action}/{id?}",
			defaults: new { Controller = "Home", Action = "Index" }
		);

		#endregion

		app.Run();
	}

}