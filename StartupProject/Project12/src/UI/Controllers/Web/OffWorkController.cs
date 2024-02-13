using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Abstraction.Service.Work;
using UI.Dto.Work;
using UI.Extension;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
public class OffWorkController : Controller {
    private readonly IOffWorkService _offWorkService;

    public OffWorkController(IOffWorkService offWorkService) {
        _offWorkService = offWorkService;
    }


    [HttpGet]
    public IActionResult Approve(Guid id) {
        return View("List");
    }


    [HttpGet]
    public async Task<IActionResult> List() {
        var response = await _offWorkService.ListOffWorkRelationalAsync();
        return this.ResponseView(response);
    }


    [HttpGet]
    public IActionResult Create() {
        return View(new OffWorkCreateDto());
    }


    [HttpPost]
    public async Task<IActionResult> Create(OffWorkCreateDto dto) {
        dto.EmployeeId = Guid.Parse(User.GetCurrentUserId());
        var response = await _offWorkService.CreateOffWorkAsync(dto);
        return this.ResponseRedirectToActionForValidation(response, "List", dto);
    }

}
