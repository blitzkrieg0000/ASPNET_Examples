using Application.Dtos.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.ApiSignIn;


public class ApiSignInRequest : IRequest<ApiSignInResponse> {
    public UserSignInDto UserSignInDto { get; set; }

    public ApiSignInRequest(UserSignInDto userSignInDto) {
        this.UserSignInDto = userSignInDto;
    }
}
