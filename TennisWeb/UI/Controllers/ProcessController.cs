using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.ProcessDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers {

    public class ProcessController : Controller {

        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService) {
            _processService = processService;
        }

        [HttpGet]
        public IActionResult Index(long id) {
            return View(new SessionIdDto() { SessionId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProcessCreateDto model) {
            var response = await _processService.Create(model);
            return RedirectToAction("Index", "Process", new { @id = model.SessionId });
        }

        public async Task<IActionResult> Remove(long id, long sessionId) {
            var response = await _processService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index", new { id = sessionId });
        }

    }
}