using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.Abstraction.Repository.EmployeeType;
using UI.Dto.EmployeeType;

namespace UI.ViewComponents.RelationalDropDowns;


public class EmployeeTypeCategoryDropdown : ViewComponent {
    private readonly IEmployeeTypeQueryRepository _employeeTypeQueryRepository;
    private readonly IMapper _mapper;

    public EmployeeTypeCategoryDropdown(IEmployeeTypeQueryRepository employeeTypeQueryRepository, IMapper mapper) {
        _employeeTypeQueryRepository = employeeTypeQueryRepository;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid? id) {
        var employeeTypes = await _employeeTypeQueryRepository.GetAllAsync();
        var data = _mapper.Map<List<EmployeeTypeDto>>(employeeTypes);
        var selectList = new SelectList(data, "Id", "Name", id);
        return View("default", selectList);
    }

}
