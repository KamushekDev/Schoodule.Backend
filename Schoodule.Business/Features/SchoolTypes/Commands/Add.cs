using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolTypes
{
	public static class Add
	{
		public record Command(string Name) : IRequest<SchoolType>;

		public class Handler : IRequestHandler<Command, SchoolType>
		{
			private readonly IMapper _mapper;
			private readonly AppDbContext _context;

			public Handler(IMapper mapper, AppDbContext context)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<SchoolType> Handle(Command request, CancellationToken cancellationToken)
			{
				var schoolType = new SchoolTypeEntity {Name = request.Name};
				var result = await _context.SchoolTypes.AddAsync(schoolType, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
				return _mapper.Map<SchoolType>(result.Entity);
			}
		}
	}
}