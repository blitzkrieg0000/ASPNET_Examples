using System.Net;
using System.Net.Mime;
using System.Text.Json;
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
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null) {
                    logger.LogError(contextFeature.Error.Message);
                }
                context.Response.Redirect("/Home/Error");
            });

        });

        //! 2-API kullanırken
        // Exceptionları, kullanıcıya istenilen formatta (json) geri döndürmek için:
        // webApplication.UseExceptionHandler(builder => {

        //     builder.Run(async context => {
        //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //         context.Response.ContentType = MediaTypeNames.Application.Json;

        //         var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //         if (contextFeature != null) {

        //             logger.LogError(contextFeature.Error.Message);

        //             await context.Response.WriteAsync(JsonSerializer.Serialize(new {
        //                 StatusCodes = context.Response.StatusCode,
        //                 Message = contextFeature.Error.Message,
        //                 Title = "Hata Alındı!"
        //             }));

        //         }

        //     });

        // });

    }
}
