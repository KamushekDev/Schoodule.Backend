using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Schoodule.Core.Exceptions;

namespace Schoodule.API.Infrastructure
{
	public class ApiErrorFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ApiErrorFilter>>();
			logger.LogError(context.Exception, "Ашибка");

			if (context.Exception is UserException userException)
			{
				context.HttpContext.Response.StatusCode = userException.StatusCode;
				context.ExceptionHandled = true;
			}

			//todo: filter exceptions 
		}
	}
}