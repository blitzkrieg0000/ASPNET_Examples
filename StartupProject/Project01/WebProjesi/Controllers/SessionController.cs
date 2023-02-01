using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebProjesi.Controllers {
    public class SessionController : Controller {

        public IActionResult Index() {
            SetSession();
            ViewBag.Session = GetSession();
            return View();
        }


        private void SetSession() {
            HttpContext.Session.SetString("Test", "Bu bir session denemesidir.");
        }


        private string GetSession() {
            return HttpContext.Session.GetString("Test");
        }
    }
}