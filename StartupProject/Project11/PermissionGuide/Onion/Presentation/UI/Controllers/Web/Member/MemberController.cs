using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web.Member;


[Authorize(Policy = "MemberGroup")]
public class MemberController : Controller {
    public MemberController() {

    }


    public IActionResult Index() {
        return View();
    }

}
