using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Endpoint.AuthorizedEndpointUpdate;


public class AuthorizedEndpointUpdateCommandHandler : IRequestHandler<AuthorizedEndpointUpdateCommandRequest, AuthorizedEndpointUpdateCommandResponse> {

    private readonly IEndpointManagerService _endpointManagerService;

    public AuthorizedEndpointUpdateCommandHandler(IEndpointManagerService endpointManagerService) {
        _endpointManagerService = endpointManagerService;
    }

    public async Task<AuthorizedEndpointUpdateCommandResponse> Handle(AuthorizedEndpointUpdateCommandRequest request, CancellationToken cancellationToken) {
        await _endpointManagerService.AssignRoleEndpointAsync(request.RoleId, request.EndpointCodes, request.Type);
        return new(ResponseType.Success, "Rol yetkileri güncellendi.");
    }
}
