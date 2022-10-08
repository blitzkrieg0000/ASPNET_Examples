using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.SessionDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class SessionController : Controller {

        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService) {
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index() {
            var response = await _sessionService.GetAll();
            return this.ResponseView(response);
        }

        public IActionResult Create() {
            return View(new SessionCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SessionCreateDto dto) {
            var response = await _sessionService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _sessionService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

    }
}