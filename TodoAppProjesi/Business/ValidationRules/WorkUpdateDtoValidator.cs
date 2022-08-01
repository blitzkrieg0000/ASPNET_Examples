using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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