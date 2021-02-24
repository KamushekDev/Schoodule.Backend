using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using AutoMapper;
using Contract.Models;
using MediatR;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolFeature
{
	public static class Add
	{
		public class Command : IRequest<School>
		{
			public string Name { get; set; }
			public SchoolType Type { get; set; }
		}

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
				var school = new School
				{
					Name = command.Name,
					Type = command.Type
				};

				var entity = _mapper.Map<SchoolEntity>(school);
				var result = await _context.Schools.AddAsync(entity, token);
				return _mapper.Map<School>(result.Entity);
			}
		}
	}
}