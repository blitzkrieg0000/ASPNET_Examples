using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Hash;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.SignUp;


public class SignUpHandler : IRequestHandler<SignUpRequest, SignUpResponse> {

    private readonly IUserManagerService _userManagerService;
    private readonly IHashService _hashService;

    public SignUpHandler(IUserManagerService userManagerService, IHashService hashService) {
        _userManagerService = userManagerService;
        _hashService = hashService;
    }

    public async Task<SignUpResponse> Handle(SignUpRequest request, CancellationToken cancellationToken) {
        request.UserSignUpDto.Password = _hashService.GetHashSha3_512(request.UserSignUpDto.Password);
        var response = await _userManagerService.CreateUserAsync(request.UserSignUpDto);
        return new(response.ResponseType, response.Data, response.Message);

    }
}
