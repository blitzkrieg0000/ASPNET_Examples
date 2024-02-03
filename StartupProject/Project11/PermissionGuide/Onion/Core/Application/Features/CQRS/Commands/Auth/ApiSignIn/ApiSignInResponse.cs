using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.ApiSignIn;


public class ApiSignInResponse : Response<TokenDto> {
    public ApiSignInResponse(ResponseType responseType) : base(responseType) {
    }

    public ApiSignInResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ApiSignInResponse(ResponseType responseType, TokenDto data) : base(responseType, data) {
    }

    public ApiSignInResponse(ResponseType responseType, TokenDto data, string message) : base(responseType, data, message) {
    }

    public ApiSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ApiSignInResponse(ResponseType responseType, TokenDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ApiSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
