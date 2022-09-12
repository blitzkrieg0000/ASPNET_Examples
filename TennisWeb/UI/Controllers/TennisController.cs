using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.GRPCData;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {

    [AutoValidateAntiforgeryToken]
    public class TennisController : Controller {


        private readonly ITennisService _tennisService;
        public TennisController(ITennisService tennisService) {
            _tennisService = tennisService;
        }

        // public IActionResult GenerateProcess() {
        //     return View(new GenerateProcessModel());
        // }

        [HttpPost]
        public async Task<IActionResult> GenerateProcess(GenerateProcessModel model) {
            var response = await _tennisService.Create(model);
            return RedirectToAction("Index", "Process", new{@id = model.SessionId});
        }

    }
}