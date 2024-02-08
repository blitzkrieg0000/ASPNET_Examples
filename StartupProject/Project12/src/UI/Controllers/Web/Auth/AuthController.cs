using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Web.Auth;


public class AuthController : Controller {

    public IActionResult SignIn() {
        return View();
    }


    public async Task<IActionResult> LogOut() {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("SignIn");
    }


    public IActionResult AccessDenied() {
        ModelState.AddModelError("", "Bu sayfaya yetkili kullanıcı ile giriş yapınız.");
        return View("SignIn");
    }




}
