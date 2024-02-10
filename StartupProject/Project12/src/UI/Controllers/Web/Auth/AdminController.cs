using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web.Admin;


[Authorize]
public class AdminController : Controller {

    [Authorize]
    public IActionResult Index() {
        return View();
    }

}