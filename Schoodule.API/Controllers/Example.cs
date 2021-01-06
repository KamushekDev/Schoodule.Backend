using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schoodule.Business.Features.Example;

namespace Schoodule.API.Controllers
{
	[RoutePrefix("api/v1/Example")]
	public sealed class Example : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<Example> _logger;

		public Example(IMediator mediator, ILogger<Example> logger)
		{
			_mediator = mediator;
			_logger = logger;
			_logger.LogDebug("Example controller was created.");
		}

		[Microsoft.AspNetCore.Mvc.HttpGet("name:string")]
		[ProducesResponseType(typeof(ExampleResult), StatusCodes.Status200OK)]
		public Task<ExampleResult> Greet(string name)
		{
			_logger.LogInformation($"Info log from greet with name: {name}");
			return _mediator.Send(new Get.Command(name));
		}
	}
}