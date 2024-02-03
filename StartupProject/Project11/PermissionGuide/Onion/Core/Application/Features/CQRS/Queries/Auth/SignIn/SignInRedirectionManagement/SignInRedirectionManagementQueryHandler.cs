using Application.Consts;
using Application.Consts.Auth;
using Application.Interfaces.Service.Auth;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.Auth.SignIn.SignInRedirectionManagement;


public class SignInRedirectionManagementQueryHandler : IRequestHandler<SignInRedirectionManagementQueryRequest, SignInRedirectionManagementQueryResponse> {
    private readonly IRoleManagerService _roleManagerService;

    public SignInRedirectionManagementQueryHandler(IRoleManagerService roleManagerService) {
        _roleManagerService = roleManagerService;
    }

    public async Task<SignInRedirectionManagementQueryResponse> Handle(SignInRedirectionManagementQueryRequest request, CancellationToken cancellationToken) {
        if (!string.IsNullOrEmpty(request.Id)) {
            var roles = await _roleManagerService.GetRolesByUserAsync(Guid.Parse(request.Id));

            //! SUPERUSER || ADMIN
            if (roles.Any(x => x.RoleName == RoleDefaults.SuperUser.Name || x.RoleName == RoleDefaults.Admin.Name)) {
                return new(ResponseType.Success, SignInDefaults.RedirectionPages.AdminPage);
            }

            //! MEMBER
            if (roles.Any(x => x.RoleName == RoleDefaults.Member.Name)) {
                return new(ResponseType.Success, SignInDefaults.RedirectionPages.MemberPage);
            }
        }
        return new(ResponseType.NotAllowed, "Giriş Yapınız.");

    }
}
