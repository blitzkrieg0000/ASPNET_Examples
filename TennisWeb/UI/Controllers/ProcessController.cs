using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.ProcessDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers {
    public class ProcessController : Controller {

        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService) {
            _processService = processService;
        }

        //TODO Tüm Processleri Listele
        // [HttpGet]
        // public IActionResult Index() {
        //     return View(new SessionIdDto() { SessionId = id });
        // }

        [HttpGet]
        public IActionResult Index(long id) {
            return View(new SessionIdDto() { SessionId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProcessCreateDto model) {
            var response = await _processService.Create(model);
            return RedirectToAction("Index", "Process", new { @id = model.SessionId });
        }

    }
}