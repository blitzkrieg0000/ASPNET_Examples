using Application.Models.Role;
using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRole;


public class CreateUserRoleCommandRequest : IRequest<CreateUserRoleCommandResponse> {
    public RoleAssignmentModel Model { get; set; }

    public CreateUserRoleCommandRequest(RoleAssignmentModel model) {
        Model = model;
    }
}
