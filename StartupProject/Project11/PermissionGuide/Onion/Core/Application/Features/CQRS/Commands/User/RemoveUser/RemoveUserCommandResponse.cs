using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.User.RemoveUser;


public class RemoveUserCommandResponse : Response {
    
    public RemoveUserCommandResponse(ResponseType responseType, string message) : base(responseType, message) {

    }
}
