using Dtos.SessionDtos;
using FluentValidation;

namespace Business.ValidationRules {
    public class SessionCreateDtoValidator : AbstractValidator<SessionCreateDto> {

        public SessionCreateDtoValidator() {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.");
            //RuleFor(x=>x.StreamId).NotEmpty().WithMessage("Bir stream seçilmelidir.");
        }
    }
}