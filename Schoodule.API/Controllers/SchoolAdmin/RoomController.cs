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
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/schoolAdmin/room")]
	public sealed class RoomController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RoomController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Room> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Room>), StatusCodes.Status200OK)]
		public Task<List<Room>> Post(CancellationToken token)
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