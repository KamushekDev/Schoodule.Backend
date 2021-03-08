using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Classes
{
	public static class GetList
	{
		public record Command : IRequest<List<Class>> { }

		public class Handler : IRequestHandler<Command, List<Class>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<Class>> Handle(Command request, CancellationToken cancellationToken)
			{
				var entities = _context.Classes;

				return await _mapper.ProjectTo<Class>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}