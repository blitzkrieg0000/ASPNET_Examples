using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRoleByRoleEditor;


public class CreateUserRoleByRoleEditorCommandRequest : IRequest<CreateUserRoleByRoleEditorCommandResponse> {
    public Guid Id { get; set; }
    public string UserRoleTags { get; set; }
    
    public CreateUserRoleByRoleEditorCommandRequest(Guid id, string userRoleTags) {
        Id = id;
        UserRoleTags = userRoleTags;
    }
}
