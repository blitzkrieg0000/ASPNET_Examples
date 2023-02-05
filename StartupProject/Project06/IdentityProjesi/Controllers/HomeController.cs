using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityProjesi.Data.Entities;
using IdentityProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProjesi.Controllers {

    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager = null, RoleManager<AppRole> roleManager = null) {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult AccessDenied(string returnUrl) {
            return View();
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Create() {
            return View(new UserCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model) {
            if (ModelState.IsValid) {
                AppUser user = new() {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.Username
                };

                var identityResult = await _userManager.CreateAsync(user, model.Password);

                if (identityResult.Succeeded) {
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if (memberRole == null) {
                        await _roleManager.CreateAsync(new() {
                            Name = "Member",
                            CreatedTime = DateTime.Now
                        });
                    }

                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index");
                }

                foreach (var error in identityResult.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        public IActionResult SignIn(string returnUrl) {
            return View(new UserSignInModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model) {
            if (ModelState.IsValid) {

                var user = await _userManager.FindByNameAsync(model.Username);

                var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);

                if (signInResult.Succeeded) {

                    if (!string.IsNullOrWhiteSpace(model.ReturnUrl)) {
                        return Redirect(model.ReturnUrl);
                    }

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin")) {
                        return RedirectToAction("AdminPanel");
                    } else {
                        return RedirectToAction("Panel");
                    }

                    //signInResult.IsLockedOut
                    //signInResult.IsNotAllowed
                } else if (signInResult.IsLockedOut) {
                    var lockOutEnd = await _userManager.GetLockoutEndDateAsync(user);
                    ModelState.AddModelError("", $"Hesabınızın kilidi {(lockOutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes} dk sonra açılacaktır.");

                } else {
                    var message = string.Empty;
                    if (user != null) {
                        var failedCount = await _userManager.GetAccessFailedCountAsync(user);
                        message = $"{_userManager.Options.Lockout.MaxFailedAccessAttempts - failedCount} kez daha deneme yaparsanız, hesap geçici olarak kilitlenecektir.";
                    } else {
                        message = "Kullanıcı Adı veya Şifre Hatalı.";
                    }

                    ModelState.AddModelError("", message);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> LogOut() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult GetUserInfo() {
            
            var userName = User.Identity.Name;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel() {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult Panel() {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberPage() {
            return View();
        }


    }
}