using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UI.Middlewares;
public class ResponseEditingMiddleware {

    private RequestDelegate _requestDelegate;

    public ResponseEditingMiddleware(RequestDelegate requestDelegate) {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext context) {
        await _requestDelegate.Invoke(context);
        
        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            await context.Response.WriteAsync("Böyle Bir Sayfa Yok");
    }


}
