using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityProjesi.Data.Entities;
using IdentityProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IdentityProjesi.Controllers {

    [Authorize(Roles = "Admin")]
    public class RoleController : Controller {

        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager) {
            _roleManager = roleManager;
        }

        public IActionResult Index() {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult Create() {
            return View(new RoleCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateModel model) {

            if (ModelState.IsValid) {
                var result = await _roleManager.CreateAsync(new AppRole() {
                    CreatedTime = DateTime.Now,
                    Name = model.Name
                });
                if (result.Succeeded) {
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