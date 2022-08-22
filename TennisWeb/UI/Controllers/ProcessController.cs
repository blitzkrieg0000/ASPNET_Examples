using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class ProcessController : Controller {

        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService) {
            _processService = processService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubProcessList(long id){
            var response = await _processService.GetListByFilter(x=> x.SessionId == id);
            return this.ResponseView(response);
        }

    }
}