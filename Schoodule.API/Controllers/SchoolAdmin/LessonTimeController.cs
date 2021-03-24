using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.LessonTimes;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/schoolAdmin/lessonTime")]
	public class LessonTimeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LessonTimeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
		public Task<long> Add([FromBody] Add.Command request, CancellationToken token)
		{
			return _mediator.Send(request, token);
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<LessonTime>), StatusCodes.Status200OK)]
		public Task<List<LessonTime>> Get()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(LessonTime), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<LessonTime> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Unit> Delete(int id, CancellationToken token)
		{
			return _mediator.Send(new Delete.Command {Id = id}, token);
		}
	}
}