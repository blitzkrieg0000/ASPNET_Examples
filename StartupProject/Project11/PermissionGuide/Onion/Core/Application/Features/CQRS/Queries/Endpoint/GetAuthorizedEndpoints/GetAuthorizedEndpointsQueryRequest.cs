using MediatR;

namespace Application.Features.CQRS.Queries.Endpoint.GetAuthorizedEndpoints;


public class GetAuthorizedEndpointsQueryRequest : IRequest<GetAuthorizedEndpointsQueryResponse> {

    public Guid RoleId { get; set; }
    public Type Type { get; set; }

    public GetAuthorizedEndpointsQueryRequest(Guid roleId, Type type) {
        RoleId = roleId;
        Type = type;
    }
}
