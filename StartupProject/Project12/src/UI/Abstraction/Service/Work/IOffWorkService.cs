using UI.Common.ResponseObject;
using UI.Dto.Work;

namespace UI.Abstraction.Service.Work;


public interface IOffWorkService {

    Task<Response<List<OffWorkDto>>> ListEmployeeAsync();

    Task<Response> CreateEmployeeAsync(OffWorkCreateDto employeeDto);

}
