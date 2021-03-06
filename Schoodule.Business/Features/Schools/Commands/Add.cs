using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Schools
{
	public static class Add
	{
		public record Command(string Name, long SchoolTypeId) : IRequest<School>;

		public class Handler : IRequestHandler<Command, School>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<School> Handle(Command command, CancellationToken token)
			{
				var school = new SchoolEntity
				{
					Name = command.Name,
					SchoolTypeId = command.SchoolTypeId,
				};

				var result = await _context.Schools.AddAsync(school, token);

				await _context.SaveChangesAsync(token);
				return _mapper.Map<School>(result.Entity);
			}
		}
	}
}