using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Configurations;
using Application.Models.Endpoint;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.Endpoint.GetAuthorizedEndpoints;


public class GetAuthorizedEndpointQueryHandler : IRequestHandler<GetAuthorizedEndpointsQueryRequest, GetAuthorizedEndpointsQueryResponse> {
    private readonly IApplicationService _applicationService;
    private readonly IEndpointManagerService _endpointManagerService;

    public GetAuthorizedEndpointQueryHandler(IApplicationService applicationService, IEndpointManagerService endpointManagerService) {
        _applicationService = applicationService;
        _endpointManagerService = endpointManagerService;
    }

    public async Task<GetAuthorizedEndpointsQueryResponse> Handle(GetAuthorizedEndpointsQueryRequest request, CancellationToken cancellationToken) {

        var result = new AuthorizedEndpointListViewModel() {
            Id = request.RoleId,
            Menus = _applicationService.GetAuthorizedEndpoints(request.Type),
            Endpoints = await _endpointManagerService.GetEndpointsByRoleAsync(request.RoleId)
        };

        return new(ResponseType.Success, result);
    }
}
