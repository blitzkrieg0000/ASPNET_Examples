using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
#pragma warning disable IDE0090, IDE0060, IDE1006, IDE0051, IDE0044

namespace WebProjesi.Middlewares {
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
}