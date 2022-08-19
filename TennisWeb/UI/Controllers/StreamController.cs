using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.StreamDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {

    [RequestFormLimits(MultipartBodyLengthLimit = 209715200), RequestSizeLimit(209715200)]
    public class StreamController : Controller {

        private readonly IStreamService _streamService;
        private readonly IPlayingDatumService _playingDatumService;
        public StreamController(IStreamService streamService, IPlayingDatumService playingDatumService) {
            _streamService = streamService;
            _playingDatumService = playingDatumService;
        }

        public async Task<IActionResult> Index() {
            var data = await _streamService.GetAll();
            return this.ResponseView<List<StreamListDto>>(data);
        }

        public async Task<IActionResult> Detail(int id) {
            var data = await _streamService.GetById(id);
            return this.ResponseView(data);
        }

        public IActionResult CreateStream() {
            var data = new CreateStreamDto() {
                Name = Guid.NewGuid().ToString()
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStream(IFormFile formFile, CreateStreamDto dto) {
            if (formFile == null) {
                TempData["Upload_Message"] = "Başarısız! Dosya Okunamadı";
                return RedirectToAction("Create");
            }

            if (formFile.ContentType == "video/mp4") {

                string baseName = "";
                if (dto.Name != null) {
                    baseName = dto.Name;
                } else {
                    baseName = Guid.NewGuid().ToString();
                }
                baseName = baseName.Replace(" ", "_");
                baseName = baseName.Replace(":", "-");
                baseName = baseName.Replace("/", "-");

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
                    Source = "/assets/" + newName
                });

                TempData["Upload_Message"] = "Başarılı!";

                return this.ResponseRedirectToAction(response, "ListStream");

            } else {
                TempData["Upload_Message"] = "Başarısız! (Type: mp4 olmalıdır!)";
            }

            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStream(IFormFile formFile, StreamListDto dto) {
            var response = await _streamService.Update(dto);
            return View();
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _streamService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

    }
}