using System;
using System.IO;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Business.Services;
using Dtos.TennisDtos;
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
        
        public async Task<IActionResult> PlayingDatum() {
            var data = await _tennisService.GetPlayingData();
            return View(data.Data);
        }

        public async Task<IActionResult> ListStream() {
            var data = await _tennisService.GetStream();
            return this.ResponseView(data);
        }


        public async Task<IActionResult> Remove(int id) {
            var response = await _tennisService.Remove(id);
            return this.ResponseRedirectToAction(response, "ListCourts");
        }

        public async Task<IActionResult> DetectCourtLines(int id, bool Force = false) {
            CourtLineDetectRequestModel model = new() {
                Id = id,
                Force = Force
            };

            var lineImage = await _grpcService.DetectCourtLines(model);

            return View(lineImage.Data);
        }

        public IActionResult Upload() {
            return View();
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        public async Task<IActionResult> Upload(IFormFile formFile) {

            if (formFile == null) {
                TempData["Upload_Message"] = "Başarısız! Dosya Okunamadı";
                return RedirectToAction("Upload");
            }
            if (formFile.ContentType == "video/mp4") {
                var newName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                var path = Path.Combine("/srv/nfs/mydata/docker-tennis/assets", newName);
                var stream = new FileStream(path, FileMode.Create);

                await formFile.CopyToAsync(stream);


                //TODO HASH KONTROLÜ YAPILACAK
                // var hash = "";
                // using (var md5 = System.Security.Cryptography.MD5.Create()) {

                //     using (var streamReader = new StreamReader(formFile.OpenReadStream())) {
                //         hash = BitConverter.ToString(md5.ComputeHash(streamReader.BaseStream)).Replace("-", "");
                //     }
                // }
                // System.Console.WriteLine(hash);

                var response = await _tennisService.Create(new StreamCreateDto() {
                    Name = newName,
                    Source = "/srv/nfs/mydata/docker-tennis/assets/" + newName
                });

                TempData["Upload_Message"] = "Başarılı!";
                return this.ResponseRedirectToAction(response, "Upload");
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