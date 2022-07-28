using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Data.Contexts;
using BankApp.Data.Interfaces;
using BankApp.Data.Repositories;
using BankApp.Mappings;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class HomeController : Controller {

        // DependencyInjection yardımı ile constructordan ModelContext imizi geçirebiliyoruz. 
        // Bu sayede "new" ile sürekli oluşturmamış oluyoruz.
        // Startup tarafında "ConfigureServices" kısmında "AddDbContext" ile bunu belirtmemiz gerekiyor.
        private readonly BankContext _context; //! Contexti hiç kullanmamaya başladık. Artık silebilirizde.
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(BankContext context, IApplicationUserRepository applicationUserRepository, IUserMapper userMapper) {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index() {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAllUser()));
        }

    }
}