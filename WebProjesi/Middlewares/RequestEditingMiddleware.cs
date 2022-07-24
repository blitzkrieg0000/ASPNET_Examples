using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
#pragma warning disable IDE0090, IDE0060, IDE1006, IDE0051, IDE0044

namespace web_project.Middlewares {
    public class RequestEditingMiddleware {

        private RequestDelegate _requestDelegate;

        public RequestEditingMiddleware(RequestDelegate requestDelegate) {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context) {

            if (context.Request.Path.ToString() == "/admin") {
                await context.Response.WriteAsync("Merhaba Admin");
            } else {
                await _requestDelegate.Invoke(context);
            }

        }


    }
}