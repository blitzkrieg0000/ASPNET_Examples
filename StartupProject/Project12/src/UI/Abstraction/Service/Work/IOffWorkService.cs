using UI.Common.ResponseObject;
using UI.Dto.Work;

namespace UI.Abstraction.Service.Work;


public interface IOffWorkService {

    Task<Response<List<OffWorkDto>>> ListOffWorkRelationalAsync();

    Task<Response> CreateOffWorkAsync(OffWorkCreateDto dto);

    Task<Response> ApproveOffWorkAsync(Guid id);

}
