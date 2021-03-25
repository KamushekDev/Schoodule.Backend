using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schoodule.Business.Features.Classes;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/schoolAdmin/class")]
	public sealed class ClassController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<ClassController> _logger;

		public ClassController(IMediator mediator, ILogger<ClassController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(Class), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Class> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Class>), StatusCodes.Status200OK)]
		public Task<List<Class>> Post(CancellationToken token)
		{
			return _mediator.Send(new GetList.Command(), token);
		}

		[HttpPost]
		[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
		public Task<long> Post([FromBody] Add.Command request)
		{
			return _mediator.Send(request);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task Delete(int id, CancellationToken token)
		{
			return _mediator.Send(new Delete.Command {Id = id}, token);
		}
	}
}