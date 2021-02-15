using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schoodule.Business.Features.Example;
using Schoodule.DataAccess.Entities;

namespace Schoodule.API.Controllers
{
	[Route("api/v1/Example")]
	public sealed class ExampleController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<ExampleController> _logger;

		public ExampleController(IMediator mediator, ILogger<ExampleController> logger)
		{
			_mediator = mediator;
			_logger = logger;
			_logger.LogDebug("Example controller was created.");
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(IList<ExampleEntity>), StatusCodes.Status200OK)]
		public Task<IList<ExampleEntity>> Get()
		{
			_logger.LogDebug("Start of get all.");
			return _mediator.Send(new GetAll.Command());
		}

		[HttpGet("{name:string}")]
		[ProducesResponseType(typeof(ExampleEntity), StatusCodes.Status200OK)]
		public Task<ExampleEntity> Get(string name)
		{
			_logger.LogDebug($"Info log from greet with name: {name}");
			return _mediator.Send(new Get.Command(name));
		}

		[HttpPost("")]
		[ProducesResponseType(typeof(ExampleEntity), StatusCodes.Status200OK)]
		public Task<ExampleEntity> Post(Example example)
		{
			_logger.LogInformation($"Info log from greet with name: {example}");
			return _mediator.Send(new Add.Command(example));
		}
	}
}