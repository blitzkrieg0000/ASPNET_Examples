using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Role.CreateRole;


public class CreateRoleCommandResponse : Response {
    public CreateRoleCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateRoleCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
