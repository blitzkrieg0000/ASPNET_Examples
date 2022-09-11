using Dtos.WorkDtos;
using FluentValidation;

namespace Business.ValidationRules {
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto> {

        public WorkUpdateDtoValidator() {
            this.RuleFor(x => x.Definition).NotEmpty();
            this.RuleFor(x => x.Id).NotEmpty();
        }

    }
}