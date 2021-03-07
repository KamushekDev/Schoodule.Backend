using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.Business.Infrastructure;
using Schoodule.Core;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class Delete
	{
		public record Command : IRequest
		{
			[Required]
			public long Id { get; init; }
		}

		public class Handler : IRequestHandler<Command>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var schoolType = await _context.SchoolTypes.FindByKeysAsync(cancellationToken, request.Id);
				if (schoolType is null)
					throw new EntityNotFoundException(Errors.E3);
				_context.SchoolTypes.Remove(schoolType);
				await _context.SaveChangesAsync(cancellationToken);
				return Unit.Value;
			}
		}
	}
}