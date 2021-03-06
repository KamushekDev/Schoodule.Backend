using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.Business.Infrastructure;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class Delete
	{
		public record Command([property: Required] long Id) : IRequest;

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
					throw new EntityNotFoundException("SchoolType with that id isn't found.");
				_context.SchoolTypes.Remove(schoolType);
				await _context.SaveChangesAsync(cancellationToken);
				return Unit.Value;
			}
		}
	}
}