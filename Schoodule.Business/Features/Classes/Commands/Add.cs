using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.Business.Attributes;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;
using Schoodule.DataAccess.Enums;

namespace Schoodule.Business.Features.Classes
{
	public static class Add
	{
		[SwaggerSchemaId("AddClassCommand")]
		public record Command : IRequest<long>
		{
			[Required] public Weekday Weekday { get; init; }
			[Required] public WeekType WeekType { get; init; }
			[Required] public long LessonId { get; init; }
			[Required] public long LessonTypeId { get; init; }
			[Required] public long LessonTimeId { get; init; }
			[Required] public long SchoolId { get; init; }
			[Required] public long TeacherId { get; init; }
			[Required] public long GroupId { get; init; }
			[Required] public long RoomId { get; init; }
			public string Description { get; init; }
		};

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
				var classEntity = new ClassEntity
				{
					Description = request.Description,
					Weekday = request.Weekday,
					WeekType = request.WeekType,
					GroupId = request.GroupId,
					LessonId = request.LessonId,
					RoomId = request.RoomId,
					SchoolId = request.SchoolId,
					TeacherId = request.TeacherId,
					LessonTimeId = request.LessonTimeId,
					LessonTypeId = request.LessonTypeId
				};

				var result = await _context.Classes.AddAsync(classEntity, cancellationToken);

				await _context.SaveChangesAsync(cancellationToken);
				return (result.Entity.Id);
			}
		}
	}
}