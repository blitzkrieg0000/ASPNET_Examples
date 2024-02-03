using Application.Interfaces.Service.Auth;
using MediatR;

namespace Application.Features.CQRS.Queries.Auth.ResetPassword;


public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse> {
    private readonly ICustomAuthService _customAuthService;

    public ResetPasswordHandler(ICustomAuthService customAuthService) {
        _customAuthService = customAuthService;
    }

    public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken) {

        var response = await _customAuthService.ResetPasswordAsync(request.resetPasswordModel);

        return new(response.ResponseType, response.Message);
    }
}
