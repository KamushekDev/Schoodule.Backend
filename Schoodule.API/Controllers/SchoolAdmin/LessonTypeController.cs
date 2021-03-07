using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.LessonTypes;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[Route("api/v1/schoolAdmin/lessonType")]
	public class LessonTypeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LessonTypeController(IMediator mediator)
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
		[ProducesResponseType(typeof(List<LessonType>), StatusCodes.Status200OK)]
		public Task<List<LessonType>> Get()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(LessonType), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<LessonType> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
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