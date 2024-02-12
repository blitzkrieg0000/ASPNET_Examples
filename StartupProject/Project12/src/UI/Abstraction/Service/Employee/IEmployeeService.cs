using UI.Common.ResponseObject;
using UI.Dto.Employee;

namespace UI.Abstraction.Service.Employee;

public interface IEmployeeService {

    Task<Response<EmployeeUpdateDto>> GetByIdAsync(string id);

    Task<Response<List<EmployeeDto>>> ListEmployeeAsync();

    Task<Response> CreateEmployeeAsync(EmployeeCreateDto dto);

    Task<Response> UpdateEmployeeAsync(EmployeeUpdateDto dto);
}
