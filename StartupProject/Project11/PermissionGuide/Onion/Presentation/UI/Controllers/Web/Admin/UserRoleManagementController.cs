using Application.Attributes;
using Application.Consts.Auth;
using Application.Enums;
using Application.Features.CQRS.Commands.UserRole.CreateUserRole;
using Application.Features.CQRS.Commands.UserRole.CreateUserRoleByRoleEditor;
using Application.Features.CQRS.Commands.UserRole.RemoveUserRole;
using Application.Features.CQRS.Queries.User.RangeListUser;
using Application.Features.CQRS.Queries.UserRole.RangeListUserRole;
using Application.Models.Paginator;
using Application.Models.Role;
using Application.Models.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


public class UserRoleManagementController : Controller {
    private readonly IMediator _mediator;

    public UserRoleManagementController(IMediator mediator) {
        _mediator = mediator;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.UserRoleManagement,
        ActionType = ActionType.Reading,
        Definition = "Atanan Rolleri Görme Yetkisi",
        Identifier = EndpointDefaults.Identifier.UserRoleManagement.AssignedRoleList
    )]
    public async Task<IActionResult> AssignedRoleList([FromQuery] PaginatorModel paginatorModel, [FromRoute] Guid id, SearchModel search) {
        ViewData["ManagingRoleId"] ??= id;
        var request = new RangeListUserRoleQueryRequest(paginatorModel);

        // Search Filter
        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            ViewData["Search"] = search.Query;
            request.Filter = x => x.RoleId == id && x.User.Name.Contains(search.Query);
        } else {
            request.Filter = x => x.RoleId == id;
        }

        var response = await _mediator.Send(request);
        return this.ResponseView(response);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.UserRoleManagement,
        ActionType = ActionType.Writing,
        Definition = "Rol Atanacak Kullanıcıları Görme Yetkisi",
        Identifier = EndpointDefaults.Identifier.UserRoleManagement.RoleAssignmentList
    )]
    public async Task<IActionResult> RoleAssignmentList(PaginatorModel paginatorModel, [FromRoute] Guid id, SearchModel search) {

        ViewData["ManagingRoleId"] ??= id;
        var request = new RangeListUserRequest(paginatorModel);

        // Search Filter
        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            ViewData["Search"] = search.Query;
            request.Filter = x => !x.ApplicationUserRoles.Any(x => x.RoleId == id) && x.Username.Contains(search.Query);
        } else {
            request.Filter = x => !x.ApplicationUserRoles.Any(x => x.RoleId == id);
        }

        var response = await _mediator.Send(request);
        return this.ResponseView(response);

    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.UserRoleManagement,
        ActionType = ActionType.Writing,
        Definition = "Rol Atama Yetkisi",
        Identifier = EndpointDefaults.Identifier.UserRoleManagement.AssignRole
    )]
    public async Task<IActionResult> AssignRole(RoleAssignmentModel model) {
        var response = await _mediator.Send(new CreateUserRoleCommandRequest(model));
        return this.ResponseRedirectToActionWithCustomModel(response, "RoleAssignmentList", new { id = model.RoleId });
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.UserRoleManagement,
        ActionType = ActionType.Deleting,
        Definition = "Rol Alma Yetkisi",
        Identifier = EndpointDefaults.Identifier.UserRoleManagement.RemoveAssignedRole
    )]
    public async Task<IActionResult> RemoveAssignedRole(RoleAssignmentModel model) {
        var response = await _mediator.Send(new RemoveUserRoleCommandRequest(model));
        return this.ResponseRedirectToActionWithCustomModel(response, "AssignedRoleList", new { id = model.RoleId });
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.UserRoleManagement,
        ActionType = ActionType.Updating,
        Definition = "Rol Atama Düzenleme Yetkisi(Rol Alma ve Rol Atama)",
        Identifier = EndpointDefaults.Identifier.UserRoleManagement.AssignRolesByRoleEditor
    )]
    public async Task<IActionResult> AssignRolesByRoleEditor(Guid id, string userRoleTags) {
        var response = await _mediator.Send(new CreateUserRoleByRoleEditorCommandRequest(id, userRoleTags));
        return this.ResponseRedirectToActionWithCustomModel(response, "Update", "User", new { id });
    }

}
