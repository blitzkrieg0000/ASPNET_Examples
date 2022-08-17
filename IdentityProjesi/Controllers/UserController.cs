using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityProjesi.Data.Contexts;
using IdentityProjesi.Data.Entities;
using IdentityProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProjesi.Controllers {
    [Authorize(Roles = "Admin")]
    public class UserController : Controller {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager = null) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index() {

            //Admin Olmayanları getitir.
            // var users = _context.Users
            // .Join(_context.UserRoles,
            //     user => user.Id, userRole => userRole.UserId,
            //     (user, userRole) => new { user, userRole })
            // .Join(_context.Roles,
            //     two => two.userRole.RoleId,
            //     role => role.Id,
            //     (two, role) => new { two.user, two.userRole, role })
            // .Where(x => x.role.Name != "Admin").Select(x => new AppUser {
            //     Id = x.user.Id,
            //     AccessFailedCount = x.user.AccessFailedCount,
            //     ConcurrencyStamp = x.user.ConcurrencyStamp,
            //     Email = x.user.Email,
            //     EmailConfirmed = x.user.EmailConfirmed,
            //     Gender = x.user.Gender,
            //     ImagePath = x.user.ImagePath,
            //     NormalizedEmail = x.user.NormalizedEmail,
            //     NormalizedUserName = x.user.NormalizedUserName,
            //     PasswordHash = x.user.PasswordHash,
            //     PhoneNumber = x.user.PhoneNumber,
            //     UserName = x.user.UserName
            // }).ToList();

            //Sadece Memberları getirir. Çünkü iki adet rolümüz var.
            var users = await _userManager.GetUsersInRoleAsync("Member");

            return View(users);
        }

        public IActionResult Create() {
            return View(new UserAdminCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAdminCreateModel model) {
            if (ModelState.IsValid) {
                var user = new AppUser {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.Username
                };
                var result = await _userManager.CreateAsync(user, model.Username + "123");
                if (result.Succeeded) {

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

                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

    }
}