using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.UpdatePassword;


public class UpdatePasswordResponse : Response {
    public UpdatePasswordResponse(ResponseType responseType, string message) : base(responseType, message)
    {
    }
}
