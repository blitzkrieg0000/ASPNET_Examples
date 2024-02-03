using Application.Consts.Auth;
using Application.Extensions;
using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.UserRole.CreateUserRoleByRoleEditor;


public class CreateUserRoleByRoleEditorCommandHandler : IRequestHandler<CreateUserRoleByRoleEditorCommandRequest, CreateUserRoleByRoleEditorCommandResponse> {
    private readonly IRoleManagerService _roleManagerService;

    public CreateUserRoleByRoleEditorCommandHandler(IRoleManagerService roleManagerService) {
        _roleManagerService = roleManagerService;
    }

    public async Task<CreateUserRoleByRoleEditorCommandResponse> Handle(CreateUserRoleByRoleEditorCommandRequest request, CancellationToken cancellationToken) {
        List<Guid> roles;
        if (!string.IsNullOrEmpty(request.UserRoleTags)) {
            var roleTags = request.UserRoleTags.JsonDeserialize<List<Dictionary<string, string>>>();
            roles = roleTags.Select(x => Guid.Parse(x["value"])).ToList();
        } else {
            roles = new() { RoleDefaults.Member.Id };
        }
        await _roleManagerService.AssignRoleRangeByUserAsync(request.Id, roles);
        return new(ResponseType.Success, "Kullanıcı rolü düzenlendi.");
    }
}
