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

namespace Schoodule.Business.Features.Teachers
{
	public static class Get
	{
		public record Command : IRequest<Teacher>
		{
			[Required]
			public long Id { get; init; }
		}

		public class Handler : IRequestHandler<Command, Teacher>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Teacher> Handle(Command request, CancellationToken cancellationToken)
			{
				var lessonTime = await _context.Teachers.FindByKeysAsync(cancellationToken, request.Id);
				if (lessonTime is null)
					throw new EntityNotFoundException(Errors.E4);
				return _mapper.Map<Teacher>(lessonTime);
			}
		}
	}
}