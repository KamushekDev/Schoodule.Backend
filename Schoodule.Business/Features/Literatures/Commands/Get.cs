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

namespace Schoodule.Business.Features.Literatures
{
	public static class Get
	{
		public record Command : IRequest<Literature>
		{
			[Required]
			public long Id { get; init; }
		}

		public class Handler : IRequestHandler<Command, Literature>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Literature> Handle(Command request, CancellationToken cancellationToken)
			{
				var literature = await _context.Literatures.FindByKeysAsync(cancellationToken, request.Id);
				if (literature is null)
					throw new EntityNotFoundException(Errors.E5);
				return _mapper.Map<Literature>(literature);
			}
		}
	}
}