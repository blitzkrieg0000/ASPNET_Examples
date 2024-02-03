using Application.Dtos.Role;
using Application.Interfaces.Repository.Role;
using Application.Interfaces.Repository.UserRole;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.Role.ListRole;


public class ListRoleQueryHandler : IRequestHandler<ListRoleQueryRequest, ListRoleQueryResponse> {
    private readonly IRoleQueryRepository _roleQueryRepository;
    private readonly IMapper _mapper;

    public ListRoleQueryHandler(IRoleQueryRepository roleQueryRepository, IMapper mapper) {
        _roleQueryRepository = roleQueryRepository;
        _mapper = mapper;
    }

    public async Task<ListRoleQueryResponse> Handle(ListRoleQueryRequest request, CancellationToken cancellationToken) {
        var roles = await _roleQueryRepository.GetAllAsync();
        var mapped = _mapper.Map<List<RoleDto>>(roles);
        return new(ResponseType.Success, mapped);
    }
}
