using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Groups
{
	public static class Add
	{
		public record Command : IRequest<long>
		{
			[Required] public string Name { get; init; }
			[Required] public long SchoolId { get; init; }
		};

		public class Handler : IRequestHandler<Command, long>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<long> Handle(Command command, CancellationToken cancellationToken)
			{
				var group = new GroupEntity
				{
					Name = command.Name,
					SchoolId = command.SchoolId,
				};

				var result = await _context.Groups.AddAsync(group, cancellationToken);

				await _context.SaveChangesAsync(cancellationToken);
				return (result.Entity.Id);
			}
		}
	}
}