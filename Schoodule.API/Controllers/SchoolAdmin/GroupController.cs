using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schoodule.Business.Features.Groups;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/schoolAdmin/group")]
	public sealed class GroupController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<GroupController> _logger;

		public GroupController(IMediator mediator, ILogger<GroupController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Group>), StatusCodes.Status200OK)]
		public Task<List<Group>> GetList()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Group> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpGet("search/{name}")]
		[ProducesResponseType(typeof(List<Group>), StatusCodes.Status200OK)]
		public Task<List<Group>> Post(string name, CancellationToken token)
		{
			return _mediator.Send(new GetList.Command {Name = name}, token);
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