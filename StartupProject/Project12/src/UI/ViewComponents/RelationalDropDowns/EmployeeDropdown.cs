using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Abstraction.Repository.Employee;
using UI.Dto.Employee;

namespace UI.ViewComponents.RelationalDropDowns;


public class EmployeeDropdown : ViewComponent {
    private readonly IEmployeeQueryRepository _employeeQueryRepository;
    private readonly IMapper _mapper;

    public EmployeeDropdown(IEmployeeQueryRepository employeeQueryRepository, IMapper mapper) {
        _employeeQueryRepository = employeeQueryRepository;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync() {
        var entityList = await _employeeQueryRepository.GetAllAsync();
        var data = _mapper.Map<List<EmployeeDto>>(entityList);


        List<SelectListItem> selectListItems = data.Select(person => new SelectListItem {
            Value = person.Id.ToString(),
            Text = $"{person.FirstName} {person.LastName}"
        }).ToList();

        SelectList selectList = new SelectList(selectListItems, "Value", "Text");

        return View("default", selectList);
    }
}
