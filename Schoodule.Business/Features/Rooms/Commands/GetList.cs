using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Rooms
{
	public static class GetList
	{
		public record Command : IRequest<List<LessonType>> { }

		public class Handler : IRequestHandler<Command, List<LessonType>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<LessonType>> Handle(Command request, CancellationToken cancellationToken)
			{
				//todo: filter by user
				var entities = _context.LessonTypes;

				return await _mapper.ProjectTo<LessonType>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}