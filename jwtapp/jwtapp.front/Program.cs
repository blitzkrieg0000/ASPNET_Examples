using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme,opt=>{
    opt.LoginPath="/Account/Login";
    opt.LogoutPath="/Account/Logout";
    opt.AccessDeniedPath="/Account/AccessDenied";
    opt.Cookie.SameSite = SameSiteMode.Strict;//ilgili domainde çalışır sadece
    opt.Cookie.HttpOnly = true;//cookie js ile paylaşımına engel
    opt.Cookie.SecurePolicy= CookieSecurePolicy.SameAsRequest;//HTTP yada HTTPS gelebilir.
    opt.Cookie.Name="JwtAppCookie";
});



var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseStaticFiles(new StaticFileOptions{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
    RequestPath="/node_modules"
});
app.UseEndpoints(enpoint => {
    enpoint.MapDefaultControllerRoute();
});


app.Run();
