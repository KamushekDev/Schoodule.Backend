using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Schoodule.Business.Infrastructure;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Schools
{
	public static class Delete
	{
		public record Command([property: Required] long Id) : IRequest;

		public class Handler : IRequestHandler<Command>
		{
			private readonly AppDbContext _context;

			public Handler(AppDbContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var entity = await _context.Schools.FindByKeysAsync(cancellationToken, request.Id);
				if (entity is null)
					throw new EntityNotFoundException($"School with id {request.Id} wasn't found.");
				_context.Schools.Remove(entity);
				await _context.SaveChangesAsync(cancellationToken);
				return Unit.Value;
			}
		}
	}
}