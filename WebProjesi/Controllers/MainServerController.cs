using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebProjesi.Controllers {
    [Route("[controller]")]
    public class MainServerController : Controller {
        private readonly ILogger<MainServerController> _logger;

        public MainServerController(ILogger<MainServerController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View("Error!");
        }
    }
}