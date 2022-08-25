using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers {


    public class CourtController : Controller {
        private readonly ICourtService _courtService;

        public CourtController(ICourtService courtService) {
            _courtService = courtService;
        }

        public async Task<IActionResult> Index() {
            var response = await _courtService.GetAllRelated();
            return this.ResponseView(response);
        }

    }
}