using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.Example
{
	public static class GetAll
	{
		public sealed class Command : IRequest<IList<ExampleEntity>> { }

		public sealed class Validator : AbstractValidator<Command>
		{
			public Validator() { }
		}

		public sealed class Handler : IRequestHandler<Command, IList<ExampleEntity>>
		{
			private readonly ILogger<Handler> _logger;
			private readonly AppDbContext _dbContext;

			public Handler(
				ILogger<Handler> logger,
				AppDbContext dbContext)
			{
				_logger = logger;
				_dbContext = dbContext;
			}

			public async Task<IList<ExampleEntity>> Handle(Command request, CancellationToken cancellationToken)
			{
				_logger.LogDebug("Start of example getall command.");
				var entities = await _dbContext.Examples.ToListAsync(cancellationToken);

				return entities;
			}
		}
	}
}