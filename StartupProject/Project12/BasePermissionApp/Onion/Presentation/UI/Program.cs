using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Persistence;
using Application;
using Microsoft.AspNetCore.ResponseCompression;
using UI.Extensions;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Globalization;
using Application.Consts;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;


internal class Program {
    private static void Main(string[] args) {

        //! BUILDER----------------------------------------------------------------------------------------------------
        var builder = WebApplication.CreateBuilder(args);

		#region Builder
        
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
		builder.Configuration.AddEnvironmentVariables(); // "ConnectionStrings__Default" gibi dışarıdan(environment variables) değer alabilmek için ayar
		#endregion


        #region Data Protection Defaults
        var dataProtector = builder.Services.AddDataProtection(opt => opt.ApplicationDiscriminator = "MasterDataProtection")
            .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA512
            }).SetApplicationName(builder.Configuration["Project:ApplicationName"]!);
			// .PersistKeysToDbContext<DefaultContext>();
        #endregion


		#region Controller Settings
		// Contollerlar ile Viewleri kullanmayı aktif ederiz ve AddControllersWithViews'in 2.overloadındaki option'lar ile Filter yapılanmalarını otomatik olarak tüm controller'ların önüne koymuş oluştururuz.
		builder.Services
        .AddControllersWithViews()                                                       // MVC
		.ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true)  // Varsayılan olarak gelen istekteki obje, controllera düşmeden validation yapılır ve hata varsa geri döndürülür. Bunu davranışı bastırabiliririz.
		.AddSessionStateTempDataProvider();     // Default olarak "CookieBasedTempDataProvider" aktiftir. Gerekli görülürse TempData'nın Session'larda tutulması için çevrilebilir. Özellikle cookie tutulmasını onaylamayan kullanıcılar giriş yaptığından oturum cookie'si tutamıyorsak işimize yarar.
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
			opt.Cookie.Name = "BasePermissionAppCookie";
			opt.ExpireTimeSpan = TimeSpan.FromDays(1);
			// opt.LoginPath = new PathString("/Home/SignIn");
			// opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
		});
		#endregion


		#region Authentication Settings
		// Authentication (COOKIE)
		builder.Services.AddAuthentication(opt => {
		    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		})
		.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt => {
		    /*
		        !=> MVC Web girişleri için authentication yönetimi
		    */
		    opt.Cookie.Name = "BasePermissionAppAuthCookie";
		    opt.Cookie.IsEssential = true;
		    opt.Cookie.HttpOnly = true;
		    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
		    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
		    opt.ExpireTimeSpan = TimeSpan.FromSeconds(double.Parse(builder.Configuration["AuthCookie:ExpireTimeSeconds"]!));
		    opt.LoginPath = new PathString("/Auth/SignIn");
		    opt.LogoutPath = new PathString("/Auth/LogOut");
		    opt.AccessDeniedPath = new PathString("/Auth/AccessDenied");
		});
        #endregion


		#region CORS Settings
		builder.Services.AddCors(cors => {
			cors.AddPolicy(PolicyDefaults.DefaultPolicyName, opt => {
				opt.WithOrigins("https://localhost", builder.Configuration["Host:Domain"]!, "https://accounts.google.com").AllowAnyHeader().AllowAnyMethod();
			});
		});
		#endregion


		#region CookiePolicy-KVKK Settings
		//! GDPR - KVKK
		builder.Services.Configure<CookiePolicyOptions>(options => {
			//Bu lambda metot, kullanıcının zorunlu olmayan işlemler için onay verip vermediğini belirler.
			//belirli bir istek için tanımlama bilgileri gereklidir.
			options.CheckConsentNeeded = context => true;
			options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
		});
		#endregion


		#region Registration Services
		// Diğer katmanlardaki extension classlardan çağırılıyor. Sadece düzeni sağlamak amacıyla buraya yazılacak bilgiler diğer katmanlarda yazılıyor.
		builder.Services.AddApplicationServices();
		builder.Services.AddPersistenceServices(builder.Configuration);
		#endregion


        #region ContextAccessor
        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        #endregion


		#region Compression
		// Dosya sıkıştırma özelliğini aktifleştir.
		builder.Services.AddResponseCompression(options => {
			options.EnableForHttps = true;
			options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
				["image/svg+xml", "image/png", "image/jpeg", "application/javascript", "text/css"]
			);
		});
		#endregion

        ////Builder
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

		// Global Exceptions Custom Middleware
		app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

		// Https'yi zorunlu kıl
        app.UseHttpsRedirection();

		#region Static Files
		var contextTypeProvider = new FileExtensionContentTypeProvider();
		
		// wwwroot klasörünü erişime açar.
		app.UseStaticFiles(new StaticFileOptions() {
			ContentTypeProvider = contextTypeProvider
		});

		// node_modules klasörünü erişime açar.
		app.UseStaticFiles(new StaticFileOptions() {
			ContentTypeProvider = contextTypeProvider,
			FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
			RequestPath = "/node_modules",
			OnPrepareResponse = ctx => { // Browser'a cache'i ne kadar tutacağını söyler. Statik dosyalar için önemlidir. Anlamak için "Cache-Control" ve "Expires" Headerlarını araştırınız.
				ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
				ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
			}
		});
		#endregion

		// GDPR - KVKK (Çerezleri kabul ediyor musunuz ? CookiePolicy.cshtml => "Hassas verilerinizi çerezlerde tutmuyoruz vs.")
		app.UseCookiePolicy();

        app.UseRouting();

		// CORS : Bilinmeyen/Saldırgan sitelerden gelen isteklerin reddi için
		app.UseCors(PolicyDefaults.DefaultPolicyName);

		// Cookie ve Session kullanabilmek için gerekli etkinleştirme.
		app.UseSession();

		// Kimlik doğrulama protokollerini etkinleştirir.
        app.UseAuthorization();

		// Yetkilendirme protokollerini etkinleştirir.
		app.UseAuthorization();

		// Gelen istekleri verilen Route pattern doğrultusunda Controller'a yönlendirir.
		app.MapControllerRoute(
			name: "default",
			pattern: "{Controller}/{Action}/{id?}",
			defaults: new { Controller = "Home", Action = "Index" }
		);

        #endregion

        app.Run();
    }
}