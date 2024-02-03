using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRoleByRoleEditor;


public class CreateUserRoleByRoleEditorCommandResponse : Response {
    public CreateUserRoleByRoleEditorCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateUserRoleByRoleEditorCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
