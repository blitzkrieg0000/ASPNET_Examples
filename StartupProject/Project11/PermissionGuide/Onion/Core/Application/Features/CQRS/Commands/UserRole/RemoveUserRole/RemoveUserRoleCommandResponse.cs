using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.UserRole.RemoveUserRole;


public class RemoveUserRoleCommandResponse : Response {
    public RemoveUserRoleCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public RemoveUserRoleCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
