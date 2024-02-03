using Application.Interfaces.Service.Auth;
using Application.Interfaces.Service.Hash;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CQRS.Commands.Auth.SignIn;


public class SignInCommandHandler : IRequestHandler<SignInCommandRequest, SignInCommandResponse> {

    private readonly ICustomAuthService _customAuthService;
    private readonly IHashService _hashService;
    readonly ILogger<SignInCommandHandler> _logger;

    public SignInCommandHandler(ICustomAuthService customAuthService, IHashService hashService, ILogger<SignInCommandHandler> logger) {
        _customAuthService = customAuthService;
        _hashService = hashService;
        _logger = logger;
    }


    public async Task<SignInCommandResponse> Handle(SignInCommandRequest request, CancellationToken cancellationToken) {
        request.UserSignInDto.Password = _hashService.GetHashSha3_512(request.UserSignInDto.Password);
        var response = await _customAuthService.SignInAsync(request.UserSignInDto);
        return new(response.ResponseType, response.Message);
    }
}
