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
			public string Symbol { get; init; }

			[Required]
			[Range(0, 23)]
			public int Hours { get; set; }

			[Required]
			[Range(0, 59)]
			public int Minutes { get; set; }

			[Required]
			public long SchoolId { get; init; }
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
				{
					Hours = request.Hours,
					Minutes = request.Minutes,
					Symbol = request.Symbol,
					SchoolId = request.SchoolId
				};
				var result = await _context.LessonTimes.AddAsync(lessonType, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
				return result.Entity.Id;
			}
		}
	}
}