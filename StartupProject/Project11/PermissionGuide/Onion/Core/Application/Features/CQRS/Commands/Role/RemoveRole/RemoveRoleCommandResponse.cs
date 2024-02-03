using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Role.RemoveRole;


public class RemoveRoleCommandResponse : Response {
    public RemoveRoleCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public RemoveRoleCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
