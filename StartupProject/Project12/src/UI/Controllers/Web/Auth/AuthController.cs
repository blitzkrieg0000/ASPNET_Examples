using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using UI.Abstraction.Service.Auth;
using UI.Abstraction.Service.Hash;
using UI.Dto.Auth;
using UI.Extension;
using UI.Extensions;

namespace UI.Controllers.Web.Auth;


public class AuthController : Controller {
    private readonly ICustomAuthService _customAuthService;
    private readonly IHashService _hashService;

    public AuthController(ICustomAuthService customAuthService, IHashService hashService) {
        _customAuthService = customAuthService;
        _hashService = hashService;
    }

    public async Task<IActionResult> SignIn() {
        var userId = HttpContext.User.GetCurrentUserId();
        var response = await _customAuthService.SignInRedirectionManagementAsync(userId);
        return this.SignInView(response);
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInDto model) {
        if (ModelState.IsValid) {
            model.Password = _hashService.GetHashSha3_512(model.Password);
            var response = await _customAuthService.SignInAsync(model);
            return this.ResponseRedirectToActionForValidation(response, "SignIn", "Auth", model);
        }
        return View(model);
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
