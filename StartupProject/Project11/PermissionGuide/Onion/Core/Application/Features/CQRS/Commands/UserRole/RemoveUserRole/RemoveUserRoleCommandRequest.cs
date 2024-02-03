using Application.Models.Role;
using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.RemoveUserRole;

public class RemoveUserRoleCommandRequest : IRequest<RemoveUserRoleCommandResponse> {
    public RoleAssignmentModel Model;

    public RemoveUserRoleCommandRequest(RoleAssignmentModel model) {
        Model = model;
    }
}
