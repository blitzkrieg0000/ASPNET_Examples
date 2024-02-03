using Application.Dtos.User;
using Application.Interfaces.Repository.User;
using AutoMapper;
using Common.ResponseObjects;
using Domain.Entities.Auth;
using MediatR;

namespace Application.Features.CQRS.Queries.User.ListUser;


public class ListUserHandler : IRequestHandler<ListUserRequest, ListUserResponse> {
    private readonly IUserQueryRepository _userQueryRepository;
    private readonly IMapper _mapper;

    public ListUserHandler(IUserQueryRepository userQueryRepository, IMapper mapper) {
        _userQueryRepository = userQueryRepository;
        _mapper = mapper;
    }


    public async Task<ListUserResponse> Handle(ListUserRequest request, CancellationToken cancellationToken) {
        List<ApplicationUser>? users;

        users = await _userQueryRepository.GetAllAsync();

        return new(ResponseType.Success, _mapper.Map<List<UserDto>>(users));
    }
}
 