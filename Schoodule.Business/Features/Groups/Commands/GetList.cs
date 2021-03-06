using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Groups
{
	public static class GetList
	{
		public record Command(string Name = null) : IRequest<List<Group>>;

		public class Handler : IRequestHandler<Command, List<Group>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<Group>> Handle(Command request, CancellationToken cancellationToken)
			{
				//todo: filter by user
				var entities = _context.Groups.FilterAndOrder(request);

				return await _mapper.ProjectTo<Group>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}