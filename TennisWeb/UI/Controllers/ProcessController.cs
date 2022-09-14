using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.ProcessDtos;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers {


    public class ProcessController : Controller {

        private readonly IProcessService _processService;
        private readonly IGRPCService _grpcService;
        public ProcessController(IProcessService processService, IGRPCService grpcService) {
            _processService = processService;
            _grpcService = grpcService;
        }

        //TODO Tüm Processleri Listele
        // [HttpGet]
        // public IActionResult Index() {
        //     return View(new SessionIdDto() { SessionId = id });
        // }

        [HttpGet]
        public IActionResult Index(long id) {
            return View(new SessionIdDto() { SessionId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProcessCreateDto model) {
            var response = await _processService.Create(model);
            return RedirectToAction("Index", "Process", new { @id = model.SessionId });
        }

        public async Task<IActionResult> Remove(long id, long sessionId) {
            var response = await _processService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index", new { id = sessionId });
        }

        //gRPC
        public async Task<IActionResult> StartProcess(long id, long sessionId) {
            var response = await _grpcService.StartProducer(id);
            return this.ResponseRedirectToAction(response, "Index", new { id = sessionId });
        }
        public async Task<IActionResult> StopProcess(long id, long sessionId) {
            var response = await _grpcService.StopProducer(id);
            return this.ResponseRedirectToAction(response, "Index", new { id = sessionId });
        }
        
    }
}