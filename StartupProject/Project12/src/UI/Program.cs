using System.Globalization;
using System.Reflection;
using Infrastructure.Services.Hash;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Persistence.Services.Auth;
using UI.Abstraction.Repository;
using UI.Abstraction.Repository.Role;
using UI.Abstraction.Repository.User;
using UI.Abstraction.Repository.UserRole;
using UI.Abstraction.Service.Auth;
using UI.Abstraction.Service.Hash;
using UI.Const.Auth;
using UI.Contexts;
using UI.Extension;
using UI.Repositories;
using UI.Repositories.Role;
using UI.Repositories.User;
using UI.Repository.UserRole;


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
            builder.Configuration.AddJsonFile("appsettings.Application.json", false, true);
            Console.WriteLine("Production Settings Activated");
        }
        builder.Configuration.AddEnvironmentVariables(); // "ConnectionStrings__Default" gibi dışarıdan değer alabilmek için ayar
        #endregion


        #region Data Protection Defaults
        var dataProtector = builder.Services.AddDataProtection(opt => opt.ApplicationDiscriminator = "MasterDataProtection")
            .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA512
            }).SetApplicationName("WebApp")
            .PersistKeysToDbContext<DefaultContext>();
        #endregion


        #region HttpContext DI
        builder.Services.AddHttpContextAccessor();
        #endregion


        #region DBContext DI
        builder.Services.AddDbContext<DefaultContext>(opt => {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
            opt.LogTo(Console.WriteLine, LogLevel.Information);
        });
        #endregion


        #region Controller Settings
        // Contollerlar ile Viewleri kullanmayı aktif ederiz ve option'lar ile Filter yapılanmalarını otomatik olarak tüm controller'ların önüne koymuş oluştururuz.
        builder.Services.AddControllersWithViews()
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
        });
        #endregion


        #region Authorization Settings
        //! Endpoint rol ataması vb. kullanılmadığı zaman statik olarak olarak Rol işlemlerini yönetir.
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


        #region AutoMapper
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        #endregion


        #region ContextAccessor
        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        #endregion

        #region Service Registration
        //! Respositories
        builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
        builder.Services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        builder.Services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();
        builder.Services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        builder.Services.AddScoped<IUserRoleQueryRepository, UserRoleQueryRepository>();
        builder.Services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();

        //! Internal Services
        builder.Services.AddScoped<ICustomAuthService, CustomAuthService>();
        builder.Services.AddScoped<IUserManagerService, UserManagerService>();
        builder.Services.AddScoped<IRoleManagerService, RoleManagerService>();

        //! External Services
        builder.Services.AddScoped<IHashService, HashService>();
        #endregion


        #region Compression
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

        if (app.Environment.IsDevelopment()) {
            app.UseHsts(); // Developer modda çalışırken gerekli (https -> http downgrade)
        }

        //Exception Handler
        app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");

        // NotFound sayfasının konumunu ayarlar.
        app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());


        // Enforce Https
        app.UseHttpsRedirection();


        // wwwroot klasörünü erişime açar.
        var contextTypeProvider = new FileExtensionContentTypeProvider();
        app.UseStaticFiles(new StaticFileOptions() {
            ContentTypeProvider = contextTypeProvider
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

        // Cookie ve Session kullanabilmek için gerekli etkinleştirme.
        app.UseSession();

        // Kimlik doğrulama protokollerini etkinleştirir.
        app.UseAuthentication();

        // Yetkilendirme protokollerini etkinleştirir.
        app.UseAuthorization();

        //* Tüm sayfalar için endpoint kullanarak belirli bir patern ile routing:
        app.MapControllerRoute(
                name: "default",
                pattern: "{Controller}/{Action}/{id?}",
                defaults: new { Controller = "Home", Action = "Index" }
            );
        #endregion

        app.Run();
    }
}
