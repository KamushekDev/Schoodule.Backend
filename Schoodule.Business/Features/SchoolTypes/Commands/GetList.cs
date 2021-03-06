using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class GetList
	{
		public record Command(string Name = null) : IRequest<List<SchoolType>>;

		public class Handler : IRequestHandler<Command, List<SchoolType>>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public Task<List<SchoolType>> Handle(Command request, CancellationToken cancellationToken)
			{
				var result = _context.SchoolTypes.FilterAndOrder(request);
				return _mapper.ProjectTo<SchoolType>(result)
					.ToListAsync(cancellationToken);
			}
		}
	}
}