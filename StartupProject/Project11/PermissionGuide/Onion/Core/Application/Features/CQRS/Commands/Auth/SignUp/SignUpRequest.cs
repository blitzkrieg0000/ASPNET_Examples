using Application.Dtos.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.SignUp;


public class SignUpRequest : IRequest<SignUpResponse> {

    public UserSignUpDto? UserSignUpDto { get; set; }

    public SignUpRequest(UserSignUpDto? userSignUpDto) {
        UserSignUpDto = userSignUpDto;
    }
}
