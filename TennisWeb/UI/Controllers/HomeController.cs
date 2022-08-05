using System.Threading.Tasks;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class HomeController : Controller {
        private readonly ITennisService _tennisService;
        public HomeController(ITennisService workService) {
            _tennisService = workService;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> ListCourts() {
            var data = await _tennisService.GetPlayingData();
            return View(data.Data);
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _tennisService.Remove(id);
            return this.ResponseRedirectToAction(response, "ListCourts");
        }

        public async Task<IActionResult> DetectCourtLines() {

            

        }

        public IActionResult NotFound(int code) {
            return View();
        }

    }
}