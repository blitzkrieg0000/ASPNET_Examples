using Dtos.StreamDtos;
using FluentValidation;

namespace Business.ValidationRules {
    public class StreamCreateDtoValidator : AbstractValidator<StreamCreateDto> {

        public StreamCreateDtoValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Zorunludur.");
        }

    }
}