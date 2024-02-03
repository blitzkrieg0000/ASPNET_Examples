using Application.Dtos.Role;
using MediatR;

namespace Application.Features.CQRS.Commands.Role.CreateRole;


public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse> {
    public RoleCreateDto RoleCreateDto { get; set; }

    public CreateRoleCommandRequest(RoleCreateDto roleCreateDto) {
        RoleCreateDto = roleCreateDto;
    }
}
