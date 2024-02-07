using Microsoft.AspNetCore.Diagnostics;

namespace UI.Extensions;


public static class ConfigureExceptionHandlerExtension {
    /*
        Global Exeptionları Yönetmek İçin Middleware
    */
    public static void ConfigureExceptionHandler<T>(this WebApplication webApplication, ILogger<T> logger) {
        //! 1-MVC kullanırken
        // Exceptionları göstermek yerine "Bir hata oluştu" mesajı vermek için
        webApplication.UseExceptionHandler(builder => {
            builder.Run(async context => {

                await Task.Run(() => {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) {
                        logger.LogError(contextFeature.Error.Message);
                    }
                    context.Response.Redirect("/Home/Error");
                });
            });

        });
    }

}