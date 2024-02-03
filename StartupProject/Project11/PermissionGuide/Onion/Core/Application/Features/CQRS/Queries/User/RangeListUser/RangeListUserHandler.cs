using Application.Interfaces.Repository.User;
using Application.Models.User;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using X.PagedList;

namespace Application.Features.CQRS.Queries.User.RangeListUser;


public class RangeListUserHandler : IRequestHandler<RangeListUserRequest, RangeListUserResponse> {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IMapper _mapper;

    public RangeListUserHandler(IUserQueryRepository userQueryRepository, IMapper mapper) {
        _userQueryRepository = userQueryRepository;
        _mapper = mapper;
    }


    public async Task<RangeListUserResponse> Handle(RangeListUserRequest request, CancellationToken cancellationToken) {
        var users = await _userQueryRepository.GetRangePagedListWithRelationsAsync(request.PaginatorModel.Page, request.PaginatorModel.Range, request.Filter);
        var pagedViewModel = _mapper.Map<IPagedList<UserViewModel>>(users);
        return new(ResponseType.Success, pagedViewModel);
    }

}
