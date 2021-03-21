using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.Rooms;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[Route("api/v1/schoolAdmin/room")]
	public sealed class RoomController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RoomController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Room>), StatusCodes.Status200OK)]
		public Task<List<Room>> Get()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Room> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpGet("search/{name}")]
		[ProducesResponseType(typeof(List<Room>), StatusCodes.Status200OK)]
		public Task<List<Room>> Post(string name, CancellationToken token)
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