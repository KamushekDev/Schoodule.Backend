using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Schoodule.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Schoodule.Business.Features.Example
{
	public static class Get
	{
		public sealed class Command : IRequest<ExampleResult>
		{
			[Required] public string Name { get; }

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

		public sealed class Handler : IRequestHandler<Command, ExampleResult>
		{
			private readonly ILogger<Handler> _logger;

			public Handler(ILogger<Handler> logger)
			{
				_logger = logger;
			}

			public Task<ExampleResult> Handle(Command request, CancellationToken cancellationToken)
			{
				_logger.LogDebug("Start of example request");
				var result = $"Hello, {request.Name}!";
				return Task.FromResult(new ExampleResult(result));
			}
		}
	}
}