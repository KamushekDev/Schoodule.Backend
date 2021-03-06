using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contract.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.SchoolTypes;

namespace Schoodule.API.Controllers.SystemAdmin
{
	[Route("api/v1/systemAdmin/schoolType")]
	public class SchoolTypeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SchoolTypeController(IMediator mediator)
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
		[ProducesResponseType(typeof(List<SchoolType>), StatusCodes.Status200OK)]
		public Task<List<SchoolType>> Get()
		{
			return _mediator.Send(new GetList.Command());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(typeof(SchoolType), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task<SchoolType> Get(int id)
		{
			return _mediator.Send(new Get.Command(id));
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
		public Task Delete(int id, CancellationToken token)
		{
			return _mediator.Send(new Delete.Command(id), token);
		}
	}
}