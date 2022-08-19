using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class TennisController : Controller {

        private readonly IGeneralService _generalService;
        private readonly IGRPCService _grpcService;
        public TennisController(IGeneralService generalService, IGRPCService grpcService) {
            _generalService = generalService;
            _grpcService = grpcService;
        }

        public async Task<IActionResult> PrepareProcessData() {
            var data = await _generalService.GetAll();
            return this.ResponseView(data);
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