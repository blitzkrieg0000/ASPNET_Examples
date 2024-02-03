using Application.Dtos.UserRole;
using Application.Interfaces.Repository.UserRole;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using X.PagedList;

namespace Application.Features.CQRS.Queries.UserRole.RangeListUserRole;


public class RangeListUserRoleQueryHandler : IRequestHandler<RangeListUserRoleQueryRequest, RangeListUserRoleQueryResponse> {
    private readonly IUserRoleQueryRepository _userRoleQueryRepository;
    private readonly IMapper _mapper;

    public RangeListUserRoleQueryHandler(IUserRoleQueryRepository userRoleQueryRepository, IMapper mapper) {
        _userRoleQueryRepository = userRoleQueryRepository;
        _mapper = mapper;
    }

    public async Task<RangeListUserRoleQueryResponse> Handle(RangeListUserRoleQueryRequest request, CancellationToken cancellationToken) {
        var pagedList = await _userRoleQueryRepository.GetRangePagedListWithRelationsAsync(request.PaginatorModel.Page, request.PaginatorModel.Range, request.Filter);
        var mappedData = _mapper.Map<IPagedList<UserRoleDto>>(pagedList);
        return new(ResponseType.Success, mappedData);
    }
}
