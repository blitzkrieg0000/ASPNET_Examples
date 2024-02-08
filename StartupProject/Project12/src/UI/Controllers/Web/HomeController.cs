using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web;


public class HomeController : Controller {
    public HomeController() {

    }

    public IActionResult Index() {
        return RedirectToAction("SignIn", "Auth");
        //TODO return View();
    }


    public IActionResult Privacy() {
        return View();
    }


    //! STATUS PAGE
    public IActionResult NotFound(int code) {
        return View();
    }


    //! ERROR 404 PAGE
    public IActionResult Error() {
        return View();
    }


    //! FORBIDDEN 403 PAGE
    public IActionResult Forbidden() {
        HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        return View();
    }
}
