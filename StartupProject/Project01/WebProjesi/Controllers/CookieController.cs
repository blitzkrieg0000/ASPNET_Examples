using System;
using Microsoft.AspNetCore.Mvc;


namespace WebProjesi.Controllers {
    public class CookieController : Controller {

        public IActionResult Index() {
            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }


        private void SetCookie() {
            HttpContext.Response.Cookies.Append("Test", "Bu bir Test Coookie sidir.", new Microsoft.AspNetCore.Http.CookieOptions {
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true, //document.cookie ile javascriptten cookie çekmeyi kapatırsın.
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict //Strict: Sadece aynı site bu cookie yi kullanabilir. Lax: SubDomainler de bu cookie'yi kullanabilir.
            });
        }

        
        private string GetCookie() {
            string cookieValue = String.Empty;
            HttpContext.Request.Cookies.TryGetValue("Test", out cookieValue);
            return cookieValue;
        }
    }
}