using UI.Abstraction.Service.Work;
using UI.Common.ResponseObject;
using UI.Dto.Work;

namespace UI.Service.Work;


public class OffWorkService : IOffWorkService {

    public async Task<Response> CreateEmployeeAsync(OffWorkCreateDto employeeDto) {
        throw new NotImplementedException();
    }

    public async Task<Response<List<OffWorkDto>>> ListEmployeeAsync() {
        throw new NotImplementedException();
    }
}
