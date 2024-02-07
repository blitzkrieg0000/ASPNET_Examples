using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web.Admin;


public class AdminController : Controller {

    [Authorize]
    [HttpGet]
    public IActionResult Index() {
        return View();
    }
}