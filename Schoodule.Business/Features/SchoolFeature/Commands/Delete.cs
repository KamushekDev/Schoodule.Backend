using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Schoodule.Business.Features.SchoolFeature
{
	public static class Delete
	{
		public class Command : IRequest
		{
			public int Id { get; set; }
		}

		public class Handler : IRequestHandler<Command>
		{
			public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				
			}
		}
	}
}