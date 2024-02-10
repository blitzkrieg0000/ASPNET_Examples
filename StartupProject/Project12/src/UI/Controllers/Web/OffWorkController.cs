using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web;


public class OffWorkController : Controller {

    public IActionResult Index() {
        return View();
    }

}
