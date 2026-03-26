using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SinteksApp.Application.Common.Behaviours
{
    public class LoggingPipelineBehaviour<TRequest, TResponse>(
        ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling process started for {request}");
            var metric = Stopwatch.StartNew();
            var response = await next();
            metric.Stop();

            if (metric.Elapsed.Seconds > 5)
                _logger.LogWarning($"Handling process took too much time. Maybe it needs to be refactored: {metric.Elapsed}");

            _logger.LogInformation($"Handling process done for {request} and you have response {response}");
            return response;
        }
    }

}
