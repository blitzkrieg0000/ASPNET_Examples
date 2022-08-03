using System.Threading.Tasks;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
    public class HomeController : Controller {
        private readonly ITennisService _workService;
        public HomeController(TennisService workService) {
            _workService = workService;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> ListCourts() {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        public IActionResult NotFound(int code) {
            return View();
        }


    }
}