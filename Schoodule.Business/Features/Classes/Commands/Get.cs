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

namespace Schoodule.Business.Features.Classes
{
	public static class Get
	{
		public record Command : IRequest<Class>
		{
			[Required]
			public long Id { get; init; }
		}

		public class Handler : IRequestHandler<Command, Class>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<Class> Handle(Command request, CancellationToken cancellationToken)
			{
				var entity = await _context.Classes.FindByKeysAsync(cancellationToken, request.Id);
				if (entity is null)
					throw new EntityNotFoundException(Errors.E1);
				return _mapper.Map<Class>(entity);
			}
		}
	}
}