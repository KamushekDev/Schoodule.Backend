using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Schoodule.Business
{
    public class ValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IValidator<TRequest> _validator;

        private readonly ILogger<ValidationRequestPreProcessor<TRequest>> _logger;

        public ValidationRequestPreProcessor(
            ILogger<ValidationRequestPreProcessor<TRequest>> logger,
            IValidator<TRequest> validator = null)
        {
            _validator = validator;
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (_validator == null) return;

            try
            {
                await _validator.ValidateAsync(
                    request,
                    options =>
                    {
                        options.IncludeRuleSets("default", "command");
                        options.ThrowOnFailures();
                    }, cancellationToken);
            }
            catch (ValidationException e)
            {
                _logger.LogWarning(e, e.Message);
                throw;
            }
        }
    }
}