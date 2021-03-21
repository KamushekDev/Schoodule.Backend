using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Schools
{
	public static class Add
	{
		public record Command : IRequest<long>
		{
			[Required]
			public string Name { get; init; }

			[Required]
			public long SchoolTypeId { get; init; }
		}

		public class Handler : IRequestHandler<Command, long>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<long> Handle(Command command, CancellationToken token)
			{
				var school = new SchoolEntity
				{
					Name = command.Name,
					SchoolTypeId = command.SchoolTypeId,
				};

				var result = await _context.Schools.AddAsync(school, token);

				await _context.SaveChangesAsync(token);
				return (result.Entity.Id);
			}
		}
	}
}