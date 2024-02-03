using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Application.Extensions;

public static class CookieExtension {

    public static void SetCookie<T>(this HttpContext context, string key, T value) {
        context.Response.Cookies.Append(key, JsonSerializer.Serialize<T>(value), new CookieOptions {
            Expires = DateTime.UtcNow.AddDays(10),
            HttpOnly = true, //document.cookie ile javascriptten cookie çekmeyi kapatırsın.
            SameSite = SameSiteMode.Lax //Strict: Sadece aynı site bu cookie yi kullanabilir. Lax: SubDomainler de bu cookie'yi kullanabilir.
        });
    }


    public static T? GetCookie<T>(this HttpContext context, string key) {

        context.Request.Cookies.TryGetValue(key, out string? cookieValue);
        if (cookieValue != null)
            return JsonSerializer.Deserialize<T>(cookieValue);
        return default;
    }


}
