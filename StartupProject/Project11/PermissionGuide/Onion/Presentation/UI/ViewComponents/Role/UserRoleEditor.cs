using Application.Consts;
using Application.Extensions;
using Application.Features.CQRS.Queries.Role.ListRole;
using Application.Interfaces.Service.Auth;
using Application.Models.Role;
using Application.Models.UserRoleEditor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Role;


public class UserRoleEditor : ViewComponent {
    private readonly IMediator _mediator;
    private readonly IRoleManagerService _roleManagerService;

    public UserRoleEditor(IMediator mediator, IRoleManagerService roleManagerService) {
        _mediator = mediator;
        _roleManagerService = roleManagerService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid userId) {
        var existRoles = await _mediator.Send(new ListRoleQueryRequest());
        var assignedRoles = await _roleManagerService.GetRolesByUserAsync(userId);

        string _assignedRolesIds = assignedRoles.Select(x => x.RoleId).ToArray().JsonSerialize();

        var _existRoles = new List<Dictionary<string, string>>();
        foreach (var role in existRoles.Data) {
            _existRoles.Add(
                new(){
                 { "value",role.Id.ToString()},
                 { "name", role.Name ??= "---"},
                 { "avatar",$"/{ImageDefaults.UserProfilePhoto}"},
                 { "description",""},
            });
        }

        return View("default", new UserRoleEditorModel {
            Id = userId,
            AssignedRoleIdsJson = _assignedRolesIds,
            ExistRolesJson = _existRoles.JsonSerialize()
        });
    }

}
