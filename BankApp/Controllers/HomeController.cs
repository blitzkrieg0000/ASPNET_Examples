using BankApp.Data.Contexts;
using BankApp.Data.Entities;
using BankApp.Data.UnitOfWork;
using BankApp.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers {
    public class HomeController : Controller {
        // DependencyInjection yardımı ile constructordan ModelContext imizi geçirebiliyoruz. 
        // Bu sayede "new" ile sürekli oluşturmamış oluyoruz.
        // Startup tarafında "ConfigureServices" kısmında "AddDbContext" ile bunu belirtmemiz gerekiyor.

        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUserMapper userMapper, IUnitOfWork unitOfWork) {
            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() {

            return View(
                _userMapper.MapToListOfUserList(

                    _unitOfWork.GetRepository<ApplicationUser>().GetAll()

                )
            );
        }

    }
}