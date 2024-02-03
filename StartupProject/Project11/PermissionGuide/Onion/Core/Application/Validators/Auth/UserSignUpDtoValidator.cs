using System.Text.RegularExpressions;
using Application.Dtos.Auth;
using FluentValidation;

namespace Application.Validators.Auth;


public class UserSignUpDtoValidator : AbstractValidator<UserSignUpDto> {

    public UserSignUpDtoValidator() {
        RuleFor(x => x.Username)
        .NotEmpty().WithMessage("İsim alanı boş olamaz.")
        .MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter olmalıdır.")
        .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakterden az olmalıdır.")
        .Must((model, name, token) => {
            return model != null &&
            name != null &&
            name != "root" &&
            Regex.IsMatch(name, @"^[a-zA-Z0-9ğüşıöçĞÜŞİÖÇ]+$") &&
            !name.Contains(' ');
        }).WithMessage("İsim alpha-numeric olmalıdır ve özel karakter içermemelidir");


        RuleFor(x => x.Password)
        .NotNull().WithMessage("Parola boş olmamalıdır.")
        .NotEmpty().WithMessage("Parola boş olmamalıdır.")
        .MinimumLength(8).WithMessage("Parola en az 8 karakter olmalıdır.") 
        .MaximumLength(150).WithMessage("Parola 150 karakterden az olmalıdır."); //SHA3-512 128 Haneli


        RuleFor(x => x.Email)
        .NotNull().WithMessage("Email boş olmamalıdır.")
        .NotEmpty().WithMessage("Email boş olmamalıdır.")
        .MinimumLength(8).WithMessage("Email en az 3 karakter olmalıdır.")
        .MaximumLength(100).WithMessage("Email 100 karakterden az olmalıdır.")
        .Must(x=> x!=null && x.Contains('@'));
    }


}
