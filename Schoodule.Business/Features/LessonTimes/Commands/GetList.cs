using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.LessonTimes
{
	public static class GetList
	{
		public record Command : IRequest<List<LessonTime>> { }

		public class Handler : IRequestHandler<Command, List<LessonTime>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<LessonTime>> Handle(Command request, CancellationToken cancellationToken)
			{
				//todo: filter by user
				var entities = _context.LessonTimes;

				return await _mapper.ProjectTo<LessonTime>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}