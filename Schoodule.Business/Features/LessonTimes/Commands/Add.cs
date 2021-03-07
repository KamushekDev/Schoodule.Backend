using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NodaTime;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.LessonTimes
{
	public static class Add
	{
		public record Command : IRequest<long>
		{
			[Required]
			public string Symbol { get; set; }

			[Required]
			public LocalTime Time { get; set; }

			[Required]
			public long SchoolId { get; set; }
		}

		public class Handler : IRequestHandler<Command, long>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<long> Handle(Command request, CancellationToken cancellationToken)
			{
				var lessonType = new LessonTimeEntity
					{Time = request.Time, Symbol = request.Symbol, SchoolId = request.SchoolId};
				var result = await _context.LessonTimes.AddAsync(lessonType, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
				return result.Entity.Id;
			}
		}
	}
}