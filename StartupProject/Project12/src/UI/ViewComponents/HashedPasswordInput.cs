using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;


public class HashedPasswordInput : ViewComponent {

    public IViewComponentResult Invoke(string name) {
        return View("default", name);
    }

}
