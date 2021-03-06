using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Schoodule.Business.Infrastructure;
using Schoodule.Core;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Schools
{
	public static class Delete
	{
		public class Command : IRequest
		{
			[Required]
			public long Id { get; init; }
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
				var entity = await _context.Schools.FindByKeysAsync(cancellationToken, request.Id);
				if (entity is null)
					throw new EntityNotFoundException(Errors.E2);
				_context.Schools.Remove(entity);
				await _context.SaveChangesAsync(cancellationToken);
				return Unit.Value;
			}
		}
	}
}