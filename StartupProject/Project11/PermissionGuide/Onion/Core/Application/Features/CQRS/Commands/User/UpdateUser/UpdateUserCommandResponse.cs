using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.User.UpdateUser;


public class UpdateUserCommandResponse : Response {
    public UpdateUserCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
