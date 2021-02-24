using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Schoodule.Core;
using Schoodule.Core.Exceptions;
using Schoodule.DataAccess;
using Schoodule.DataAccess.Entities;

namespace Schoodule.Business.Features.ExampleFeature
{
	public static class Get
	{
		public sealed class Command : IRequest<ExampleEntity>
		{
			[Required]
			public string Name { get; }

			public Command(string name)
			{
				Name = name;
			}
		}

		public sealed class Validator : AbstractValidator<Command>
		{
			public Validator()
			{
				RuleFor(r => r.Name)
					.NotEmpty()
					.WithMessage(Errors.E1);
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
				_logger.LogDebug("Start of example get command.");
				var entity = await _dbContext.Examples.FirstOrDefaultAsync(
					x => x.Name == request.Name,
					cancellationToken);
				if (entity == null)
				{
					throw new EntityNotFoundException(Errors.E2);
				}

				return entity;
			}
		}
	}
}