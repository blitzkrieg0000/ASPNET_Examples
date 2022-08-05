using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace WebProjesi {

    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services) {
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            var fullName = configuration.GetSection("Person:FullName").Value;

            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}"); //404 Page ExceptionHandler

            app.UseStaticFiles(); //wwwroot klasörünü erişime açar.
            app.UseStaticFiles(new StaticFileOptions {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
            });

            app.UseRouting();
            app.UseSession();

            // app.UseMiddleware<ResponseEditingMiddleware>();
            // app.UseMiddleware<RequestEditingMiddleware>();
            app.UseEndpoints(endpoints => {

                // endpoints.MapControllerRoute(
                //     name: "productRoute",
                //     pattern: "blitzkrieg/{action}",
                //     defaults: new { Controller = "Home" }
                // );

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}",
                    defaults: new { Controller = "Home", Action = "Index" }
                );

                //endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }

}
