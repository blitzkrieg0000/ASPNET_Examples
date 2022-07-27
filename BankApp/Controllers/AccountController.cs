using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Contexts;
using BankApp.Data.Entities;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class AccountController : Controller {

        private readonly BankContext _context;

        public AccountController(BankContext context) {
            _context = context;
        }

        public IActionResult Create(int id) {

            var userInfo = _context.ApplicationUsers.Select(x => new UserListModel {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).SingleOrDefault(x => x.Id == id);

            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model) {

            _context.Accounts.Add(new Account {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            });

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}