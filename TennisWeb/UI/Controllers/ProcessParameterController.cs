using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {
    public class ProcessParameterController : Controller {

        private readonly IProcessParameterService _processParameterService;

        public ProcessParameterController(IProcessParameterService processParameterService) {
            _processParameterService = processParameterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubProcessParameter(string id) {
            var response = await _processParameterService.GetListByFilter(x => x.Id == id);
            return this.ResponseView(response);
        }


    }
}