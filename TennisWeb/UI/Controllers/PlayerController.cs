using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.PlayerDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class PlayerController : Controller {

        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService) {
            _playerService = playerService;
        }

        public async Task<IActionResult> Index() {
            var response = await _playerService.GetAll();
            return this.ResponseView(response);
        }

        public IActionResult Create() {
            return View(new PlayerCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto dto) {
            var response = await _playerService.Create(dto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _playerService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

    }
}