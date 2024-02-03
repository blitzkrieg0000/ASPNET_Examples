using Application.Dtos.User;
using Application.Extensions;
using MediatR;

namespace Application.Features.CQRS.Commands.User.UpdateUser;


public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse> {
    private UserUpdateDto userUpdateDto;
    public UserUpdateDto UserUpdateDto {
        get { return userUpdateDto; }
        set {
            userUpdateDto = value;
            userUpdateDto.Id = value.Secret.DecryptGuid();
        }
    }

    public UpdateUserCommandRequest(UserUpdateDto userUpdateDto) {
        UserUpdateDto = userUpdateDto;
    }
}
