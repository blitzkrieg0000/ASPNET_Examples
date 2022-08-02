using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult NotFound(int code) {
            return View();
        }

    }
}