using Dtos.WorkDtos;
using FluentValidation;

namespace Business.ValidationRules {
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto> {


        public WorkCreateDtoValidator() {
            RuleFor(x => x.Definition).NotEmpty();
                // .WithMessage("Açıklama Gereklidir.").When(x=>x.IsCompleted)
                // .Must(NotThat).WithMessage("Bu mesaj 'Burakhan' olamaz! ");
        }

        private bool NotThat(string arg) {
            return arg != "Burakhan";
        }

    }
}