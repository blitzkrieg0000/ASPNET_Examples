using Application.Dtos.Auth;
using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Hash;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


[AutoValidateAntiforgeryToken]
public class AuthController(IHashService hashService, ICustomAuthService customAuthService) : Controller {
    private readonly IHashService _hashService = hashService;
    private readonly ICustomAuthService _customAuthService = customAuthService;

    [HttpGet]
    public IActionResult SignIn() {
        var userId = HttpContext.User.GetCurrentUserId();
        return userId != null ? RedirectToAction("Index", "Admin") : View();
    }


    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInDto model) {
        if (ModelState.IsValid) {

            model.Password = _hashService.GetHashSha3_512(model.Password);
            
            var response = await _customAuthService.SignInAsync(model);

            if(response.ResponseType==ResponseType.Success){
                RedirectToAction("SignIn", "Auth");
            }

        }
        return View(model);
    }


    public IActionResult SignUp() {
        return View(new UserSignUpDto());
    }


    [HttpPost]
    public async Task<IActionResult> SignUp(UserSignUpDto userSignUpDto) {
        // if (ModelState.IsValid) {
        //     var response = await _mediator.Send(new SignUpRequest(userSignUpDto));
        //     return this.ResponseRedirectToActionForValidation(response, "SignIn", "Auth", userSignUpDto);
        // }
        return View(userSignUpDto);
    }


    // [HttpGet]
    // [AllowAnonymous]
    // public async Task<IActionResult> UpdatePassword(string token) {
    //     await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    //     return View(new UpdatePasswordModel {
    //         ResetPasswordToken = token
    //     });
    // }


    // [HttpPost]
    // [AllowAnonymous]
    // //[IgnoreAntiforgeryToken] // Eğer AntiForgeryToken sorun çıkarırsa (400 bad request gibi) ignore'layabiliriz çünkü public siteler ile; yani kullanıcı bilgisinin önemsiz olduğu endpointler ile uğraşıyoruz.
    // //Genelde çoklu browser tab'i açıldığında bu sorun ortaya çıkıyor. Antiforgery Token session olarak tutuluyor ve kullanıcı farklı bir tabdan form olan bir sayfaya giriş yaparsa, bu token değeri değiştiği için sorun oluyor.
    // public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model) {
    //     if (ModelState.IsValid) {
    //         var response = await _mediator.Send(new UpdatePasswordRequest(model));
    //         return this.ResponseView(response, "Status");
    //     }
    //     return View(model);
    // }


    public async Task<IActionResult> LogOut() {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("SignIn");
    }


    public IActionResult AccessDenied() {
        ModelState.AddModelError("", "Bu sayfaya yetkili kullanıcı ile giriş yapınız.");
        return View("SignIn");
    }


}
