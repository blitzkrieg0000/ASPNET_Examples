using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers {
    public class HomeController : Controller {

        private readonly IWorkService _workService;

        public HomeController(IWorkService workService) {
            _workService = workService;
        }

        public async Task<IActionResult> Index() {
            var workList = await _workService.GetAll();
            return View(workList);
        }
    }
}