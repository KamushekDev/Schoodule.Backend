using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Schoodule.Core;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.ExampleFeature
{
	public static class Add
	{
		public sealed class Command : IRequest<ExampleEntity>
		{
			[Required]
			public Example.Example Example { get; }

			public Command(Example.Example example)
			{
				Example = example;
			}
		}

		public sealed class Validator : AbstractValidator<Command>
		{
			public Validator()
			{
				RuleFor(r => r.Example)
					.NotNull();
				RuleFor(r => r.Example.Name)
					.NotEmpty()
					.WithMessage(Errors.E1);
				RuleFor(r => r.Example.Type)
					.NotNull();
			}
		}

		public sealed class Handler : IRequestHandler<Command, ExampleEntity>
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

			public async Task<ExampleEntity> Handle(Command request, CancellationToken cancellationToken)
			{
				_logger.LogDebug("Start of example add command");

				var exampleEntity = new ExampleEntity
				{
					Name = request.Example.Name,
					NickName = request.Example.NickName,
					Type = request.Example.Type
				};

				var result = await _dbContext.AddAsync(exampleEntity, cancellationToken);

				var changes = await _dbContext.SaveChangesAsync(cancellationToken);
				_logger.LogInformation($"Added entity with id: {result.Entity.Id}");

				Debug.Assert(changes == 1, "changes == 1");

				return result.Entity;
			}
		}
	}
}