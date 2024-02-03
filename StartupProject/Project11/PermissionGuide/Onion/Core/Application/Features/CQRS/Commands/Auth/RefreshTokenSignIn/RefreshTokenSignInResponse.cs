using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.RefreshTokenSignIn {
    public class RefreshTokenSignInResponse : Response<TokenDto> {
        public RefreshTokenSignInResponse(ResponseType responseType) : base(responseType) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, string message) : base(responseType, message) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, TokenDto data) : base(responseType, data) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, TokenDto data, string message) : base(responseType, data, message) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, TokenDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
        }

        public RefreshTokenSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
        }
    }
}