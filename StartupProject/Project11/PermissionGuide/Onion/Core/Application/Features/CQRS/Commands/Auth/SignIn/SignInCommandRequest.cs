using Application.Dtos.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.SignIn;


public class SignInCommandRequest : IRequest<SignInCommandResponse> {

    public UserSignInDto UserSignInDto { get; set; }

    public SignInCommandRequest(UserSignInDto userSignInDto) {
        UserSignInDto = userSignInDto;
    }
}
