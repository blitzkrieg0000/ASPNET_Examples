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

                    await _roleManager.CreateAsync(new() {
                        Name = "Admin",
                        CreatedTime = DateTime.Now
                    });

                    await _userManager.AddToRoleAsync(user, "Admin");
                    
                    return RedirectToAction("Index");
                }

                foreach (var error in identityResult.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }


        public IActionResult SignIn() {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model) {
            if (ModelState.IsValid) {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                if (signInResult.Succeeded) {

                } else if (signInResult.IsLockedOut) {

                } else if (signInResult.IsNotAllowed) {

                }
            }
            return View(model);
        }

        [Authorize]
        public IActionResult GetUserInfo() {
            var userName = User.Identity.Name;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return View();
        }

    }
}