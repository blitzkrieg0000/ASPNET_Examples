using Application.Dtos.Configurations;
using Application.Models.Endpoint;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.Endpoint.GetAuthorizedEndpoints;


public class GetAuthorizedEndpointsQueryResponse : Response<AuthorizedEndpointListViewModel> {
    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, AuthorizedEndpointListViewModel data) : base(responseType, data) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, AuthorizedEndpointListViewModel data, string message) : base(responseType, data, message) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, AuthorizedEndpointListViewModel data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, AuthorizedEndpointListViewModel data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public GetAuthorizedEndpointsQueryResponse(ResponseType responseType, AuthorizedEndpointListViewModel data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
