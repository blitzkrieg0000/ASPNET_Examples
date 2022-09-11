using Dtos.PlayerDtos;
using FluentValidation;

namespace Business.ValidationRules {
    public class PlayerCreateDtoValidator : AbstractValidator<PlayerCreateDto> {

        public PlayerCreateDtoValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet Bilgisi Zorunludur.");
        }

    }
}