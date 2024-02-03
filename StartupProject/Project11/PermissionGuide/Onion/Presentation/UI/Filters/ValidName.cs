using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Filters;

public class ValidName : ActionFilterAttribute {

    public override void OnActionExecuting(ActionExecutingContext context) {

        var dictionary = context.ActionArguments.FirstOrDefault(item => item.Key == "name");
        var name = dictionary.Value;

        if (name != null) {
            if ("root" == ((string)name).ToLower()) {
                context.Result = new RedirectResult("/Home/Index");
            }
        }

        base.OnActionExecuting(context);
    }

}
