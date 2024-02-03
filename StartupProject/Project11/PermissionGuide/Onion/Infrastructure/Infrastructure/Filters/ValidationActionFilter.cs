using Application.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters;


public class ValidationActionFilter : IAsyncActionFilter {
    /*
        !FluentValidation'ın AutoValidation Özelliği Artık Önerilmediğinden ve Async olarak çalışmadığından dolayı bu çalışma yapılmıştır.
    */
    public static int LowerOrderThanModelStateInvalidFilter => -2001;
    private readonly IServiceProvider _serviceProvider;

    public ValidationActionFilter(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var arguments = context.ActionArguments;

        if (arguments.Count > 0) {
            foreach (var argument in arguments.Values) {
                if (argument is null) {
                    continue;
                }

                // Sadece Primitive veri varsa atla
                var argumentType = argument.GetType();
                if (argumentType.IsPrimitive || argumentType == typeof(string)) {
                    continue;
                }

                var validatorType = typeof(IValidator<>).MakeGenericType(argumentType);
                var validator = (IValidator?)_serviceProvider.GetService(validatorType);

                if (validator != null) {
                    // The ValidationContext<object> iyi görünmüyor fakat çalışıyor.
                    var result = await validator.ValidateAsync(new ValidationContext<object>(argument));
                    var errors = result.ConvertToCustomValidationError();

                    if (errors != null) {
                        foreach (var error in errors) {
                            if (error.PropertyName != null && error.ErrorMessage != null) {
                                context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                            }
                        }
                    }

                }
            }
        }

        await next();
    }
}
