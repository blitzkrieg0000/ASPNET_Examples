using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Abstraction.Service.Employee;
using UI.Attribute;
using UI.Const.Auth;
using UI.Dto.Employee;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
[AutoValidateAntiforgeryToken]
public class EmployeeController : Controller {
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) {
        _employeeService = employeeService;
    }

    [Roles(AuthRoleDefaults.Manager, AuthRoleDefaults.HumanResources, AuthRoleDefaults.IT)]
    public async Task<IActionResult> List() {
        var response = await _employeeService.ListEmployeeAsync();
        return this.ResponseView(response);
    }


    [HttpGet]
    [Roles(AuthRoleDefaults.Manager, AuthRoleDefaults.HumanResources)]
    public IActionResult Create() {
        return View(new EmployeeCreateDto());
    }


    [HttpPost]
    [Roles(AuthRoleDefaults.Manager, AuthRoleDefaults.HumanResources)]
    public async Task<IActionResult> Create(EmployeeCreateDto dto) {
        var response = await _employeeService.CreateEmployeeAsync(dto);
        return this.ResponseRedirectToActionForValidation(response, "List", dto);
    }


    [HttpGet]
    [Roles(AuthRoleDefaults.Manager, AuthRoleDefaults.HumanResources, AuthRoleDefaults.IT)]
    public async Task<IActionResult> Update(string id) {
        var response = await _employeeService.GetByIdAsync(id);
        return this.ResponseView(response);
    }


    [HttpPost]
    [Roles(AuthRoleDefaults.Manager, AuthRoleDefaults.HumanResources, AuthRoleDefaults.IT)]
    public async Task<IActionResult> Update(EmployeeUpdateDto dto) {
        if (ModelState.IsValid) {
            var response = await _employeeService.UpdateEmployeeAsync(dto);
            return this.ResponseRedirectToActionForValidation(response, "List", dto);
        }
        return this.View(dto);
    }
}
