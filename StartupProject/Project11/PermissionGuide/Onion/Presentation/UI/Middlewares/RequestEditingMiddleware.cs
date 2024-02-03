using System.Net.Http.Headers;

namespace UI.Middlewares;
public class RequestEditingMiddleware {

    private RequestDelegate _requestDelegate;

    public RequestEditingMiddleware(RequestDelegate requestDelegate) {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext context) {

        // if (context.Request.Path.ToString() == "/admin") {
        //     await context.Response.WriteAsync("Merhaba Admin");

        // } else {
        //     await _requestDelegate.Invoke(context);
        // }

        // var jwt = context.GetCookie<string>("jwtCookie");
        // if (jwt != null) {
        //     context.Request.Headers.Authorization = "Bearer " + jwt;
        // }
        await _requestDelegate.Invoke(context);

    }


}
