using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.PlayingDatumDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class PlayingDatumController : Controller {
        private readonly IPlayingDatumService _playingDatumService;

        public PlayingDatumController(IPlayingDatumService playingDatumService) {
            _playingDatumService = playingDatumService;
        }

        public async Task<IActionResult> Index() {
            var data = await _playingDatumService.GetPlayingData();
            return this.ResponseView<List<PlayingDatumListDto>>(data);
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _playingDatumService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }
    }
}