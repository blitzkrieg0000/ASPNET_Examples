using System.Security.Claims;
using CustomCookieBasedAuth.Data.Contexts;
using CustomCookieBasedAuth.Data.Enums;
using CustomCookieBasedAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomCookieBasedAuth.Controllers;


public class HomeController : Controller {

    private readonly MainContext _context;

    public HomeController(MainContext context) {
        _context = context;
    }


    public IActionResult Index() {
        return View();
    }


    public IActionResult SignIn() {
        return View(new UserSignInModel());
    }


    public IActionResult AccessDenied() {
        return View(); 
    }


    [Authorize(Roles = "SuperUser")]
    public IActionResult Admin() {
        return View();
    }


    [Authorize(Roles = "SuperUser, Member")]
    public IActionResult Member() {

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInModel model) {

        // CRUD
        var user = _context.ApplicationUser.SingleOrDefault(x => x.Name == model.Username && x.Password == model.Password);

        if (user == null || model.Username == null) {
            return View(model);
        }
        var roles = _context.ApplicationRole.Where(x => x.Id == user.Id).Select(x => x.Name).ToList();

        if (user != null) {

            //! Claim
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, model.Username)
            };

            foreach (var item in roles) {
                if (item != null)
                    claims.Add(new Claim(ClaimTypes.Role, item));
            }

            //! Kullanıcı Kimliği
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //! Kullanıcı Oturum Ayarı
            var authProperties = new AuthenticationProperties {
                // AllowRefresh = true,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),

                IsPersistent = model.Remember,

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            try {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            } catch {
                return View(model);
            }

            return RedirectToAction("Admin");

        }

        ModelState.AddModelError("", "Kullanıcı adı ve Şifre hatalıdır.");
        return View(model);

    }


    public async Task<IActionResult> LogOut() {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }


}
