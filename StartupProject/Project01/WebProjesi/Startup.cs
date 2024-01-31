using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;


namespace WebProjesi {

	public class Startup {
		//Bu yöntem çalışma zamanı tarafından çağrılır. Kapsayıcıya hizmet eklemek için bu yöntemi kullanın.
		//Uygulamanızı nasıl yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkID=398940 adresini ziyaret edin.

		public void ConfigureServices(IServiceCollection services) {
			services.AddSession();
			services.AddControllersWithViews();
		}


		//Bu yöntem çalışma zamanı tarafından çağrılır. HTTP istek ardışık düzenini yapılandırmak için bu yöntemi kullanın.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			var fullName = configuration.GetSection("Person:FullName").Value;

			app.UseExceptionHandler("/Home/Error");
			app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}"); // 404 Page ExceptionHandler

			app.UseStaticFiles(); // wwwroot klasörünü erişime açar.
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
					pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}",
					defaults: new { Areas = "Member", Controller = "Home", Action = "Index" }
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
