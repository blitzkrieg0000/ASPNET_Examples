using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRole;


public class CreateUserRoleCommandResponse : Response {
    public CreateUserRoleCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateUserRoleCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
