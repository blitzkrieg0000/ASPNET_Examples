using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.GRPCData;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
    
    [AutoValidateAntiforgeryToken]
    public class TennisController : Controller {

        private readonly IGRPCService _grpcService;
        public TennisController(IGRPCService grpcService) {
            _grpcService = grpcService;
        }

        public IActionResult PrepareProcessData() {
            return View(new StartGameObservationRequestModel());
        }

        public async Task<IActionResult> DetectCourtLines(DetectCourtLinesRequestModel model) {
            var lineImage = await _grpcService.DetectCourtLines(model);
            return View(lineImage.Data);
        }

        public async Task<IActionResult> StartGameObservation(StartGameObservationRequestModel model) {
            var data = await _grpcService.StartGameObservation(model);
            return View(data.Data);
        }
    }
}