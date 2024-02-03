using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.ApiRefreshTokenSignIn;


public class ApiRefreshTokenSignInResponse : Response<TokenDto> {
    public ApiRefreshTokenSignInResponse(ResponseType responseType) : base(responseType) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, TokenDto data) : base(responseType, data) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, TokenDto data, string message) : base(responseType, data, message) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, TokenDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ApiRefreshTokenSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
