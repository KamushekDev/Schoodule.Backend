using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Schoodule.Business.Infrastructure;
using Schoodule.Core;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class Get
	{
		public record Command : IRequest<SchoolType>
		{
			[Required]
			public long Id { get; init; }
		}

		public class Handler : IRequestHandler<Command, SchoolType>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<SchoolType> Handle(Command request, CancellationToken cancellationToken)
			{
				var schoolType = await _context.SchoolTypes.FindByKeysAsync(cancellationToken, request.Id);
				if (schoolType is null)
					throw new EntityNotFoundException(Errors.E3);
				return _mapper.Map<SchoolType>(schoolType);
			}
		}
	}
}