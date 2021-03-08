using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Teachers
{
	public static class GetList
	{
		public record Command : IRequest<List<Teacher>> { }

		public class Handler : IRequestHandler<Command, List<Teacher>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<Teacher>> Handle(Command request, CancellationToken cancellationToken)
			{
				var entities = _context.Teachers;

				return await _mapper.ProjectTo<Teacher>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}