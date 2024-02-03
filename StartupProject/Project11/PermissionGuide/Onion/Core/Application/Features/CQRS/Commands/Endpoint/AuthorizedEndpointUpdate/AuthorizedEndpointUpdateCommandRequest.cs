using MediatR;

namespace Application.Features.CQRS.Commands.Endpoint.AuthorizedEndpointUpdate;

public class AuthorizedEndpointUpdateCommandRequest : IRequest<AuthorizedEndpointUpdateCommandResponse> {
    public Guid RoleId { get; set; }
    public string[]? EndpointCodes { get; set; }
    public Type Type { get; set; }

    public AuthorizedEndpointUpdateCommandRequest(Guid roleId, string[]? endpointCodes, Type type) {
        RoleId = roleId;
        EndpointCodes = endpointCodes;
        Type = type;
    }
}
