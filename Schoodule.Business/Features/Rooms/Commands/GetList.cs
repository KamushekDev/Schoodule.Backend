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
		public record Command : IRequest<List<Room>> { }

		public class Handler : IRequestHandler<Command, List<Room>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<Room>> Handle(Command request, CancellationToken cancellationToken)
			{
				var entities = _context.Rooms;

				return await _mapper.ProjectTo<Room>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}