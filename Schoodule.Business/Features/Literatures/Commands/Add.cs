using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Literatures
{
	public static class Add
	{
		public record Command : IRequest<long>
		{
			[Required]
			public string Name { get; init; }
			public string Uri { get; init; }

			[Required]
			public long LessonId { get; init; }
			
			[Required]
			public long GroupId { get; init; }
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
				var literature = new LiteratureEntity
				{
					Name = request.Name,
					Uri = request.Uri,
					LessonId = request.LessonId,
					GroupId = request.GroupId
				};
				var result = await _context.Literatures.AddAsync(literature, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
				return result.Entity.Id;
			}
		}
	}
}