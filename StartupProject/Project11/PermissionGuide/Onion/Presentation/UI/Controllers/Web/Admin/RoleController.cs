using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.Role;
using Application.Enums;
using Application.Extensions;
using Application.Features.CQRS.Commands.Role.CreateRole;
using Application.Features.CQRS.Commands.Role.RemoveRole;
using Application.Features.CQRS.Queries.Role.ListRole;
using Application.Models.Role;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


[Authorize(Policy = "AdminGroup")]
public class RoleController : Controller {
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator) {
        _mediator = mediator;
    }


    public IActionResult Index() {
        return View();
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Role,
        ActionType = ActionType.Reading,
        Definition = "Rol Listeleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Role.List
    )]
    public async Task<IActionResult> List(ListRoleQueryRequest listRoleQueryRequest) {
        var response = await _mediator.Send(listRoleQueryRequest);
        return this.ResponseView(response);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Role,
        ActionType = ActionType.Writing,
        Definition = "Rol Oluşturma Yetkisi",
        Identifier = EndpointDefaults.Identifier.Role.Create
    )]
    public IActionResult Create() {
        return View(new RoleCreateDto());
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Role,
        ActionType = ActionType.Writing,
        Definition = "Rol Oluşturma Yetkisi",
        Identifier = EndpointDefaults.Identifier.Role.Create
    )]
    public async Task<IActionResult> Create(RoleCreateDto dto) {

        if (ModelState.IsValid) {
            var response = await _mediator.Send(new CreateRoleCommandRequest(dto));
            return this.ResponseRedirectToActionForValidation(response, "List", dto);
        }

        return View(dto);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Role,
        ActionType = ActionType.Deleting,
        Definition = "Rol Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Role.Delete
    )]
    public async Task<IActionResult> Remove(RemoveRoleCommandRequest request) {
        var response = await _mediator.Send(request);
        return this.ResponseRedirectToAction(response, "List");
    }

}
