using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.CourtDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {


    public class CourtController : Controller {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService) {
            _courtService = courtService;
        }

        public async Task<IActionResult> Index() {
            var response = await _courtService.GetAllRelated();
            return this.ResponseView(response);
        }

        public IActionResult Create() {
            return View(new CourtCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourtCreateDto dto) {
            var response = await _courtService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }
        
        public async Task<IActionResult> Remove(int id) {
            var response = await _courtService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

    }
}