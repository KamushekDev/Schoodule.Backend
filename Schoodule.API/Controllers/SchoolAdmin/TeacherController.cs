using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.Teachers;

namespace Schoodule.API.Controllers.SchoolAdmin
{
	[ApiController]
	[ApiVersion("0.1")]
	[Route("api/schoolAdmin/teacher")]
	public sealed class TeacherController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TeacherController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Teacher>), StatusCodes.Status200OK)]
		public Task<List<Teacher>> GetList()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(Teacher), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<Teacher> Get(int id)
		{
			return _mediator.Send(new Get.Command {Id = id});
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