using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebProjesi.Models;

namespace WebProjesi.Filters {
    public class ValidFirstName : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext context) {
            
            var dictionary = context.ActionArguments.FirstOrDefault(item => item.Key == "customer");
            var customer = (Customer)dictionary.Value;

            if (customer.FirstName == "blitz"){
                context.Result = new RedirectResult("/Home/Index");
            }
            //base.OnActionExecuting(context);
        }

    }
}