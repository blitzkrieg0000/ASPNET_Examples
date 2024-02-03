using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web;


public class Home : Controller {


    public IActionResult Index() {
        return View();
    }



}
