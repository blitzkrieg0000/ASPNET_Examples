using System;
using System.IO;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class HomeController : Controller {
        private readonly ITennisService _tennisService;
        private readonly IGRPCService _grpcService;
        public HomeController(ITennisService workService, IGRPCService grpcService) {
            _tennisService = workService;
            _grpcService = grpcService;
        }

        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> ListCourts() {
            var data = await _tennisService.GetPlayingData();
            return View(data.Data);
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _tennisService.Remove(id);
            return this.ResponseRedirectToAction(response, "ListCourts");
        }

        public async Task<IActionResult> DetectCourtLines() {

            CourtLineDetectRequestModel model = new() {
                Id = 9,
                Force = false
            };
            await _grpcService.DetectCourtLines(model);

            return View();
        }

        public IActionResult Upload() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile) {


            if (formFile.ContentType == "video/mp4") {
                var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/video", newName);
                var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream);

                TempData["Upload_Message"] = "Başarılı!";
            } else {
                TempData["Upload_Message"] = "Başarısız! (Type: mp4 olmalıdır!)";
            }

            return RedirectToAction("Upload");
        }


        public IActionResult NotFound(int code) {
            return View();
        }

    }
}