using CustomCookieBasedAuth.Data.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//! Services



//Auth Cookie
builder.Services.AddDbContext<MainContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"), builder => {
        builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null);
    });
    opt.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => {
    opt.Cookie.Name = "CustomAuthCookie";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.ExpireTimeSpan = TimeSpan.FromDays(10);
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.LogoutPath = new PathString("/Home/LogOut");
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
});


var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => {

    // Home/Index/?id
    endpoints.MapDefaultControllerRoute();

});

app.Run();
