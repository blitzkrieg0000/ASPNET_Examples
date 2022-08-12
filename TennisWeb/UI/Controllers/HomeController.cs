using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.GRPCData;
using Business.Interfaces;
using Dtos.TennisDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class HomeController : Controller {

        private readonly IPlayingDatumService _playingDatumService;
        private readonly IGRPCService _grpcService;
        private readonly IStreamService _streamService;
        private readonly IGeneralService _generalService;

        public HomeController(IPlayingDatumService playingDatumService, IGRPCService grpcService, IStreamService streamService, IGeneralService generalService = null) {
            _playingDatumService = playingDatumService;
            _streamService = streamService;
            _grpcService = grpcService;
            _generalService = generalService;
        }

        //! LIST
        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> ListPlayingDatum() {
            var data = await _playingDatumService.GetPlayingData();
            return this.ResponseView<List<PlayingDatumListDto>>(data);
        }

        public async Task<IActionResult> ListStream() {
            var data = await _streamService.GetAll();
            return this.ResponseView<List<StreamListDto>>(data);
        }

        public async Task<IActionResult> StreamDetail(int id) {
            var data = await _streamService.GetById(id);
            return this.ResponseView(data);
        }

        public async Task<IActionResult> PrepareProcessData() {
            var data = await _generalService.GetAll();
            return this.ResponseView(data);
        }


        //! REMOVE
        public async Task<IActionResult> Remove(int id) {
            var response = await _playingDatumService.Remove(id);
            return this.ResponseRedirectToAction(response, "ListPlayingDatum");
        }

        public async Task<IActionResult> RemoveStream(int id) {

            var response = await _streamService.Remove(id);

            return this.ResponseRedirectToAction(response, "ListStream");
        }


        //! CREATE
        public IActionResult CreateStream() {
            var data = new CreateStreamDto() {
                Name = Guid.NewGuid().ToString()
            };
            return View(data);
        }

        [HttpPost, RequestFormLimits(MultipartBodyLengthLimit = 209715200), RequestSizeLimit(209715200)]
        public async Task<IActionResult> CreateStream(IFormFile formFile, CreateStreamDto dto) {

            if (formFile == null) {
                TempData["Upload_Message"] = "Başarısız! Dosya Okunamadı";
                return RedirectToAction("CreateStream");
            }

            if (formFile.ContentType == "video/mp4") {

                string baseName = "";
                if (dto.Name != null) {
                    baseName = dto.Name;
                } else {
                    baseName = Guid.NewGuid().ToString();
                }

                var newName = baseName + Path.GetExtension(formFile.FileName);
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

                var response = await _playingDatumService.Create(new StreamCreateDto() {
                    Name = newName,
                    Source = "/srv/nfs/mydata/docker-tennis/assets/" + newName
                });

                TempData["Upload_Message"] = "Başarılı!";

                return this.ResponseRedirectToAction(response, "ListStream");

            } else {
                TempData["Upload_Message"] = "Başarısız! (Type: mp4 olmalıdır!)";
            }

            return RedirectToAction("CreateStream");
        }

        [HttpPost, RequestFormLimits(MultipartBodyLengthLimit = 209715200), RequestSizeLimit(209715200)]
        public async Task<IActionResult> UpdateStream(IFormFile formFile, StreamListDto dto) {
            var response = await _streamService.Update(dto);
            return View();
        }


        //! ALGORITMS 
        public async Task<IActionResult> DetectCourtLines(DetectCourtLinesRequestModel model) {
            var lineImage = await _grpcService.DetectCourtLines(model);
            return View(lineImage.Data);
        }

        public async Task<IActionResult> StartGameObservation(StartGameObservationRequestModel model) {
            var data = await _grpcService.StartGameObservation(model);
            return View(data.Data);
        }


        //! ERRORS
        public IActionResult NotFound(int code) {
            return View();
        }


    }
}