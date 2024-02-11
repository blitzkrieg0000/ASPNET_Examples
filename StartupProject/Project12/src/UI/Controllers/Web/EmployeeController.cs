using Microsoft.AspNetCore.Mvc;
using UI.Abstraction.Service.Employee;
using UI.Dto.Employee;
using UI.Extensions;

namespace UI.Controllers.Web;


public class EmployeeController : Controller {
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) {
        _employeeService = employeeService;
    }


    public async Task<IActionResult> List() {
        var response = await _employeeService.ListEmployeeAsync();
        return this.ResponseView(response);
    }


    [HttpGet]
    public IActionResult Create() {
        return View(new EmployeeCreateDto());
    }


    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDto dto) {
        await _employeeService.CreateEmployeeAsync(dto);
        return RedirectToAction("List", "Employee");
    }


    [HttpGet]
    public IActionResult Update() {
        return View(new EmployeeUpdateDto());
    }


    [HttpPost]
    public async Task<IActionResult> Update(EmployeeUpdateDto dto) {
        await _employeeService.UpdateEmployeeAsync(dto);
        return RedirectToAction("List", "Employee");
    }
}
