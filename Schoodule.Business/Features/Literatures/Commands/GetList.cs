using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;

namespace Schoodule.Business.Features.Literatures
{
	public static class GetList
	{
		public record Command : IRequest<List<Literature>>
		{
			[Required]
			public string Name { get; init; }
		}

		public class Handler : IRequestHandler<Command, List<Literature>>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<List<Literature>> Handle(Command request, CancellationToken cancellationToken)
			{
				//todo: filter by user
				var entities = _context.Literatures.FilterAndOrder(request);

				return await _mapper.ProjectTo<Literature>(entities)
					.ToListAsync(cancellationToken);
			}
		}
	}
}