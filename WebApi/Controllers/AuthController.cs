using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        [HttpPost]
        public IActionResult Login() {
            return Created("", new JwtTokenGenerator().GenerateToken());
        }
    }
}