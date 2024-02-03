using Application.Attributes;
using Application.Consts.Auth;
using Application.Enums;
using Application.Extensions;
using Application.Features.CQRS.Commands.Endpoint.AuthorizedEndpointUpdate;
using Application.Features.CQRS.Queries.Endpoint.GetAuthorizedEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Admin;


[Authorize(Policy = "AdminGroup")]
public class EndpointController : Controller {
    private readonly IMediator _mediator;

    public EndpointController(IMediator mediator) {
        _mediator = mediator;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Endpoint,
        ActionType = ActionType.Reading,
        Definition = "Endpoint Görüntüleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Endpoint.List
    )]
    public async Task<IActionResult> AuthorizedEndpointList(Guid id) {
        var response = await _mediator.Send(new GetAuthorizedEndpointsQueryRequest(id, typeof(Program)));
        return this.ResponseView(response);
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Endpoint,
        ActionType = ActionType.Updating,
        Definition = "Endpoint Güncelleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Endpoint.Update
    )]
    public async Task<IActionResult> AuthorizedEndpointUpdate(Guid id, string codes) {
        var endpointCodes = codes.JsonDeserialize<string[]>();
        var response = await _mediator.Send(new AuthorizedEndpointUpdateCommandRequest(id, endpointCodes, typeof(Program)));
        return this.ResponseRedirectToActionWithCustomModel(response, "AuthorizedEndpointList", new { id });
    }

}
