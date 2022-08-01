using System.Threading.Tasks;
using Business.Interfaces;
using Common.ResponseObjects;
using Dtos.WorkDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class HomeController : Controller {

        private readonly IWorkService _workService;
        public HomeController(IWorkService workService) {
            _workService = workService;
        }

        public async Task<IActionResult> Index() {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        public IActionResult Create() {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto) {

            var response = await _workService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");

        }

        public async Task<IActionResult> Update(int id) {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto) {
            //if (ModelState.IsValid) { //Zaten business tarafında validasyon yapıyoruz.
            var response = await _workService.Update(dto);

            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult NotFound(int code) {
            return View();
        }

    }
}