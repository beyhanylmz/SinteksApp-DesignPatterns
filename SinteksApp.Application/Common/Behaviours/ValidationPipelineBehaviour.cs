using FluentValidation;
using MediatR;
using SinteksApp.Application.Common.Exceptions;

namespace SinteksApp.Application.Common.Behaviours
{
    public class ValidationPipelineBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators ?? throw new ArgumentNullException(nameof(validators));

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();

            var validationContext = new ValidationContext<TRequest>(request);
            var validationResponse = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(validationContext, cancellationToken)));

            var validationErrors = validationResponse
                .SelectMany(x => x.Errors)
                .Where(e => e != null)
                .Select(x => x.ErrorMessage)
                .ToList();

            if (validationErrors.Any()) throw new ValidationFailedException(validationErrors);
            
            return await next();
        }
    }

}
