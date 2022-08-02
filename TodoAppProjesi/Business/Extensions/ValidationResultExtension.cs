using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.ResponseObjects;
using FluentValidation.Results;

namespace Business.Extensions {
    public static class ValidationResultExtension {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult) {

            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors) {
                errors.Add(new() {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            
            return errors;
        }
    }
}