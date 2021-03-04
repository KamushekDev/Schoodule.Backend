using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

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
			private readonly AppDbContext _context;

			public Handler(AppDbContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var entity = await _context.Schools.FindAsync(
					new object[] {request.Id},
					cancellationToken);
				if (entity is null)
					throw new EntityNotFoundException($"School with id {request.Id} wasn't found.");
				_context.Schools.Remove(entity);
				await _context.SaveChangesAsync(cancellationToken);
				return Unit.Value;
			}
		}
	}
}