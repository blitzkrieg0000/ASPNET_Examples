using AutoMapper;
using UI.Abstraction.Repository.OffWork;
using UI.Abstraction.Service.Work;
using UI.Common.ResponseObject;
using UI.Dto.Work;
using UI.Entity.Concrete.Work;

namespace UI.Service.Work;


public class OffWorkService : IOffWorkService {
    private readonly IOffWorkQueryRepository _offWorkQueryRepository;
    private readonly IOffWorkCommandRepository _offWorkCommandRepository;
    private readonly IMapper _mapper;

    public OffWorkService(IOffWorkQueryRepository offWorkQueryRepository, IOffWorkCommandRepository offWorkCommandRepository, IMapper mapper) {
        _offWorkQueryRepository = offWorkQueryRepository;
        _offWorkCommandRepository = offWorkCommandRepository;
        _mapper = mapper;
    }


    public async Task<Response> ApproveOffWorkAsync(Guid id) {
        var entity = await _offWorkQueryRepository.GetByIdAsync(id);
        entity.IsApproved=true;
        await _offWorkCommandRepository.UpdateAsync(entity);
        await _offWorkCommandRepository.SaveAsync();
        return new(ResponseType.Success, "Başarıyla Onaylandı.");
    }


    public async Task<Response> CreateOffWorkAsync(OffWorkCreateDto dto) {
        var data = _mapper.Map<OffWork>(dto);
        data.OffEnd = data.OffEnd.ToUniversalTime();
        data.OffStart = data.OffStart.ToUniversalTime();
        await _offWorkCommandRepository.CreateAsync(data);
        await _offWorkCommandRepository.SaveAsync();
        return new(ResponseType.Success);
    }


    public async Task<Response<List<OffWorkDto>>> ListOffWorkRelationalAsync() {
        var entity = await _offWorkQueryRepository.ListOffWorkRelationalAsync();
        var data = _mapper.Map<List<OffWorkDto>>(entity);
        return new(ResponseType.Success, data);
    }
    
}
