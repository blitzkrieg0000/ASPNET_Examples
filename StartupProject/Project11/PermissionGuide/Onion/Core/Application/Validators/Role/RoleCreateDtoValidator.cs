using System.Text.RegularExpressions;
using Application.Dtos.Role;
using FluentValidation;

namespace Application.Validators.Role;


public class RoleCreateDtoValidator : AbstractValidator<RoleCreateDto> {
    public sbyte MaxNameLength { get; set; } = 30;

    public RoleCreateDtoValidator() {
        RuleFor(x => x.Name)
        .NotNull().WithMessage("İsim boş bırakılmamalıdır.")
        .NotEmpty().WithMessage("İsim boş bırakılmamalıdır.")
        .MinimumLength(0).WithMessage("İsim boş bırakılmamalıdır.")
        .MaximumLength(MaxNameLength).WithMessage($"İsim {MaxNameLength} karakterden az olmalıdır.")
        .Must(x =>
            x != null &&
            !(Regex.IsMatch(x, @"[^\u0020-\u007E]") || Regex.IsMatch(x, @"[^a-zA-Z\d\s:]"))
        ).WithMessage("Sadece alfa-numerik karakterler kullanılmalıdır.");
    }

}