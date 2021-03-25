using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schoodule.Business.Features.Schools;

namespace Schoodule.API.Controllers.SystemAdmin
{
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/systemAdmin/school")]
	public sealed class SchoolController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<SchoolController> _logger;

		public SchoolController(IMediator mediator, ILogger<SchoolController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<School>), StatusCodes.Status200OK)]
		public Task<List<School>> Get()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(School), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<School> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpPost]
		[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
		public Task<long> Post([FromBody] Add.Command request)
		{
			return _mediator.Send(request);
		}

		[HttpGet("search/{name}")]
		[ProducesResponseType(typeof(List<School>), StatusCodes.Status200OK)]
		public Task<List<School>> Post(string name, CancellationToken token)
		{
			return _mediator.Send(new GetList.Command {Name = name}, token);
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