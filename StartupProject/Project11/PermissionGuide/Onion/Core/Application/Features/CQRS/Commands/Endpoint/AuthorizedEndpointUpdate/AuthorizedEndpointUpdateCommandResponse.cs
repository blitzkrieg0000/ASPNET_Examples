using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Endpoint.AuthorizedEndpointUpdate;


public class AuthorizedEndpointUpdateCommandResponse : Response {
    public AuthorizedEndpointUpdateCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public AuthorizedEndpointUpdateCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
