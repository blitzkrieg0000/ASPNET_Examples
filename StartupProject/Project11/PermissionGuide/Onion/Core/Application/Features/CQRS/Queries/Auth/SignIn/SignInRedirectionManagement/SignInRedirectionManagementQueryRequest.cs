using MediatR;

namespace Application.Features.CQRS.Queries.Auth.SignIn.SignInRedirectionManagement;


public class SignInRedirectionManagementQueryRequest : IRequest<SignInRedirectionManagementQueryResponse> {
    public string Id { get; set; }

    public SignInRedirectionManagementQueryRequest(string id) {
        Id = id;
    }
}
