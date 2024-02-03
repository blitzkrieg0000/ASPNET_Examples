using System.Text.RegularExpressions;
using Application.Consts;
using Application.Dtos.User;
using FluentValidation;


namespace Application.Validators.Auth;

public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto> {
    public string[] Genders = new[] { GenderDefaults.Male, GenderDefaults.Female, GenderDefaults.Unspecified };

    public UserUpdateDtoValidator() {
        RuleFor(x => x.Gender)
        .NotEmpty().WithMessage("Cinsiyet boş olamaz.")
        .NotNull().WithMessage("Cinsiyet boş olamaz.")
        .Must(x => x != null && Genders.Contains(x)).WithMessage("Cinsiyet doğru seçilmedi.");


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


        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("İsim alanı boş olamaz.")
        .MinimumLength(6).WithMessage("İsim en az 6 karakter olmalıdır.")
        .MaximumLength(50).WithMessage("İsim 50 karakterden az olmalıdır.")
        .Must((model, name, token) => {
            return model != null &&
            name != null &&
            name != "root" &&
            Regex.IsMatch(name, @"^[a-zA-Z0-9ğüşıöçĞÜŞİÖÇ]+$");
        }).WithMessage("İsim alpha-numeric olmalıdır ve özel karakter içermemelidir");


        RuleFor(x => x.NormalizedName)
        .NotEmpty().WithMessage("İsim alanı boş olamaz.")
        .MinimumLength(6).WithMessage("İsim en az 6 karakter olmalıdır.")
        .MaximumLength(50).WithMessage("İsim 50 karakterden az olmalıdır.")
        .Must((model, name, token) => {
            return model != null &&
            name != null &&
            name != "root" &&
            Regex.IsMatch(name, @"^[a-zA-Z0-9ğüşıöçĞÜŞİÖÇ]+$");
        }).WithMessage("İsim alpha-numeric olmalıdır ve özel karakter içermemelidir");


        RuleFor(x => x.Email)
        .NotNull().WithMessage("Email boş olmamalıdır.")
        .NotEmpty().WithMessage("Email boş olmamalıdır.")
        .MinimumLength(8).WithMessage("Email en az 3 karakter olmalıdır.")
        .MaximumLength(100).WithMessage("Email 100 karakterden az olmalıdır.")
        .Must(x => x != null && x.Contains('@'));


        RuleFor(x => x.Description)
        .MaximumLength(200).WithMessage("Açıklama 200 karakterden az olmalıdır.");
    }

}
