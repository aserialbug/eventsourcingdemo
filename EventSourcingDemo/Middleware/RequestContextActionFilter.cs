using EventSourcingDemo.Application.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventSourcingDemo.Middleware;

public class RequestContextActionFilter : IAsyncActionFilter
{
    private readonly RequestContext _requestContext;


    public RequestContextActionFilter(RequestContext requestContext)
    {
        _requestContext = requestContext;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _requestContext.AddUserContext(UserId.TestUser);
        
        await next();
    }
}

public static class Inject
{
    public static IServiceCollection FillRequestContext(this IServiceCollection serviceCollection)
        => serviceCollection.AddTransient<RequestContextActionFilter>();
}