using Application.Consts;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.Auth.SignIn.SignInRedirectionManagement;


public class SignInRedirectionManagementQueryResponse : Response<Page> {
    public SignInRedirectionManagementQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, Page data) : base(responseType, data) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, Page data, string message) : base(responseType, data, message) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, Page data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, Page data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public SignInRedirectionManagementQueryResponse(ResponseType responseType, Page data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
