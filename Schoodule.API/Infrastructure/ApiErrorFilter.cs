using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Schoodule.API.Infrastructure
{
    public class ApiErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ApiErrorFilter>>();
            logger.LogError(context.Exception, context.Exception.Message);
            //todo: filter exceptions 
        }
    }
}