using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web.Admin;


[Authorize]
public class AdminController : Controller {

    public IActionResult Index() {
        return View();
    }

}