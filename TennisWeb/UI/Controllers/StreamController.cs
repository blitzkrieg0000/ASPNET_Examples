using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.StreamDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {

    [AutoValidateAntiforgeryToken]
    [RequestFormLimits(MultipartBodyLengthLimit = 209715200), RequestSizeLimit(209715200)]
    public class StreamController : Controller {

        private readonly IStreamService _streamService;
        public StreamController(IStreamService streamService) {
            _streamService = streamService;

        }

        public async Task<IActionResult> Index() {
            var data = await _streamService.GetAll();
            return this.ResponseView<List<StreamListDto>>(data);
        }

        public async Task<IActionResult> Detail(int id) {
            var data = await _streamService.GetById(id);
            return this.ResponseView<StreamListDto>(data);
        }

        public IActionResult Create() {
            TempData["Upload_Message"] = null;
            return View(new StreamCreateDto() {
                Name = Guid.NewGuid().ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile formFile, StreamCreateDto dto) {
            var response = await _streamService.Create(formFile, dto);
            return this.ResponseRedirectToAction<StreamCreateDto>(response, "Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(IFormFile formFile, StreamListDto dto) {
            var response = await _streamService.Update(dto);
            return View();
        }

        public async Task<IActionResult> Remove(int id) {
            var response = await _streamService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

    }
}