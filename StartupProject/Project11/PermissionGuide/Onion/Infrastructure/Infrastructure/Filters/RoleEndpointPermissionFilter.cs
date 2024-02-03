using System.Reflection;
using Application.Attributes;
using Application.Extensions;
using Application.Interfaces.Service.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Infrastructure.Filters;


public class RoleEndpointPermissionFilter : IAsyncActionFilter {
    private readonly IRoleManagerService _roleManagerService;

    public RoleEndpointPermissionFilter(IRoleManagerService roleManagerService) {
        _roleManagerService = roleManagerService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var name = context.HttpContext.User.Identity?.Name;
        if (!string.IsNullOrEmpty(name) && name != "root") {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var attribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(AuthorizeEndpointAttribute)) as AuthorizeEndpointAttribute;
            if (attribute is null) {
                await next();
            }
            var httpAttribute = descriptor?.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

            // var code = $"{attribute?.Identifier}.{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute?.ActionType}.{attribute?.Definition.GetSha256Hash()}";
            var code = $"{attribute?.Identifier}";
            //TODO Kullanıcının rolleri bu koda sahip mi?
            var hasRole = await _roleManagerService.HasRolePermissionForEndpointAsync(name, code);

            if (!hasRole) {
                context.Result = new RedirectToActionResult("Forbidden", "Home", new { });
            } else {
                await next();
            }
        } else
            await next();
    }


}
