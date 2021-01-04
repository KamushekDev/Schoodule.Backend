using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoodule.Business.Features.Example;

namespace Schoodule.API.Controllers
{
	[RoutePrefix("api/v1/Example")]
	public sealed class Example : ControllerBase
	{
		private readonly IMediator _mediator;

		public Example(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Microsoft.AspNetCore.Mvc.HttpGet("name:string")]
		[ProducesResponseType(typeof(ExampleResult), StatusCodes.Status200OK)]
		public Task<ExampleResult> Greet(string name)
		{
			return _mediator.Send(new Get.Command(name));
		}
	}
}