using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Contexts;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class HomeController : Controller {

        // DependencyInjection yardımı ile constructordan ModelContext imizi geçirebiliyoruz. 
        // Bu sayede "new" ile sürekli oluşturmamış oluyoruz.
        // Startup tarafında "ConfigureServices" kısmında "AddDbContext" ile bunu belirtmemiz gerekiyor.
        private readonly BankContext _context;
        public HomeController(BankContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var userData = _context.ApplicationUsers.Select(x => new UserListModel {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
            return View(userData);
        }
    }
}