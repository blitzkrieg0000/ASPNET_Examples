using Microsoft.AspNetCore.Mvc;
namespace UI.Controllers {
    public class HomeController : Controller {

        //! MAIN PAGE
        public IActionResult Index() {
            return View();
        }

        //! NOTFOUND PAGE
        public IActionResult NotFound(int code) {
            return View();
        }

    }
}