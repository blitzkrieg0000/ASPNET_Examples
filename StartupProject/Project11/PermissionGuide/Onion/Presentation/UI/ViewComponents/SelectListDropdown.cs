using Application.Models.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.ViewComponents;


public class SelectListDropdown : ViewComponent {

    public IViewComponentResult Invoke(SelectListDropdownOptions opts) {
        

        var selected = opts.SelectedId != null ? opts.SelectedId.ToString() : (opts.Dto.FirstOrDefault()?.Id.ToString() ?? "");

        SelectList data = new(opts.Dto, opts.ValueField, opts.NameField, selected);

        ViewData["SelectListName"] = opts.SelectListName;
        return View("default", data);
    }

}
