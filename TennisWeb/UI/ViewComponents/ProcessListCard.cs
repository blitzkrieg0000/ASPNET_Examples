using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents {
    public class ProcessListCard : ViewComponent {

        private readonly IProcessService _processService;

        public ProcessListCard(IProcessService processService) {
            _processService = processService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long sessionId){
            var response = await _processService.GetAllRelated(sessionId);
            // var response = await _processService.GetListByFilter(x=> x.SessionId == sessionId);
            return View(response.Data);
        }

    }
}