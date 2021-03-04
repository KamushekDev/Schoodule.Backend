using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contract.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.SchoolFeature
{
	public static class Get
	{
		public class Command : IRequest<School>
		{
			public int? Id { get; set; }
			public string Name { get; set; }
		}

		public class Handler : IRequestHandler<Command, School>
		{
			private readonly AppDbContext _context;
			private readonly IMapper _mapper;

			public Handler(AppDbContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<School> Handle(Command request, CancellationToken cancellationToken)
			{
				if (request.Id.HasValue)
				{
					var entity = await _context.Schools.FindAsync(new object[]{request.Id.Value}, cancellationToken);
					if (entity is null)
						throw new EntityNotFoundException($"School with id {request.Id} wasn't found.");
					return _mapper.Map<School>(entity);
				}
				
				//todo: fix exception
				throw new UserException("Пашол нахой, без id не входи.");
			}
		}
	}
}