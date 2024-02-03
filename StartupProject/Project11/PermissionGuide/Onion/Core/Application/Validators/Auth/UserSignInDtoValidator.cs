
using Application.Dtos.Auth;
using FluentValidation;

namespace Application.Validators.Auth;
public class UserSignInDtoValidator : AbstractValidator<UserSignInDto> {

    public UserSignInDtoValidator() {
        RuleFor(x => x.Username)
        .NotEmpty().WithMessage("Kullanıcı Adı Zorunludur.")
        .MinimumLength(3).WithMessage("Kullanıcı Adı veya Şifre Yanlış.");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Parola Zorunludur.")
        .MinimumLength(128).WithMessage("Parola Zorunludur.")
        .MaximumLength(128).WithMessage("Parola Karar Verilen Hash Algoritması ile gönderilmelidir.");
    }

}
