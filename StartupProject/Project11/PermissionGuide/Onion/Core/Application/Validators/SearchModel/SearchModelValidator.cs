using System.Text.RegularExpressions;
using FluentValidation;
using S = Application.Models.Search;

namespace Application.Validators.SearchModel;


public class SearchModelValidator : AbstractValidator<S::SearchModel> {
    public sbyte MaxNameLength { get; set; } = 50;

    public SearchModelValidator() {
        RuleFor(x => x.Query)
        .MaximumLength(MaxNameLength).WithMessage($"Başlık {MaxNameLength} karakterden az olmalıdır.")
        .Must(x =>
            x != null &&
            Regex.IsMatch(x, @"^[a-zA-Z0-9ğüşıöçĞÜŞİÖÇ]+$")
        ).WithMessage("Aramada sadece alfa-numerik karakterler kullanılmalıdır.");
    }
}
