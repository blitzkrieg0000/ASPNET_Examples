using Common.ResponseObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace UI.Behaviors;


public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : IRequest<TResponse>
where TResponse : Response {
    private readonly IActionContextAccessor _actionContextAccessor;

    public ValidatorBehavior(IActionContextAccessor actionContextAccessor) {
        _actionContextAccessor = actionContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        
        

        return await next();
        
        // //! Before Handler-------------------------------------------------------------------------------------------------------------------------
        // if (_actionContextAccessor.ActionContext != null && _actionContextAccessor.ActionContext.ModelState.IsValid) {
        //     return await next();
        // }


        // var instance = (TResponse)Activator.CreateInstance(typeof(TResponse), ResponseType.ValidationError);
        // return instance;
    }
}