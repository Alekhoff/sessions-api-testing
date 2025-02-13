using Microsoft.AspNetCore.Mvc.Filters;

namespace PersonsApi.Actions;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Executing action: {context.ActionDescriptor.DisplayName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Finished action: {context.ActionDescriptor.DisplayName}");
    }

}