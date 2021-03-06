using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Schools
{
	public static class GetList
	{
		public record Command(string Name = null) : IRequest<List<School>>;

		public class Handler : IRequestHandler<Command, List<School>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<School>> Handle(Command request, CancellationToken cancellationToken)
			{
				//todo: filter by user
				var entities = _context.Schools as IQueryable<SchoolEntity>;

				if (request.Name is not null)
				{
					entities = entities.Where(
						x => x.Name.ToUpper()
							.Contains(request.Name.ToUpper()));
				}

				return await _mapper.ProjectTo<School>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}