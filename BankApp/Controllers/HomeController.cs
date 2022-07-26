using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class HomeController : Controller {

        private readonly BankContext _context;

        public HomeController(BankContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View(_context.ApplicationUsers.ToList());
        }
    }
}