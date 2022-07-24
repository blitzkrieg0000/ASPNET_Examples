using Microsoft.AspNetCore.Mvc;

namespace WebProjesi.Controllers {

    public class ProductController : Controller {

        public IActionResult Index(int id){
            return View();
        }

    }

}