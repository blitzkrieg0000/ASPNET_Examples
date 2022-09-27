using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.PlayingDatumDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {

    [AutoValidateAntiforgeryToken]
    public class PlayingDatumController : Controller {


        private readonly IPlayingDatumService _playingDatumService;
        public PlayingDatumController(IPlayingDatumService playingDatumService) {
            _playingDatumService = playingDatumService;
        }


        public async Task<IActionResult> Index() {
            var data = await _playingDatumService.GetAllRelated();
            return this.ResponseView<List<PlayingDatumRelatedListDto>>(data);
        }


        public async Task<IActionResult> Test() {
            var data = await _playingDatumService.GetAllRelated();
            return this.ResponseView<List<PlayingDatumRelatedListDto>>(data);
        }


        public async Task<IActionResult> Detail(int id) {
            var data = await _playingDatumService.GetById(id);
            return this.ResponseView<PlayingDatumListDto>(data);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PlayingDatumCreateDto model) {
            var response = await _playingDatumService.Create(model);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(int id) {
            var response = await _playingDatumService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }
        

    }
}