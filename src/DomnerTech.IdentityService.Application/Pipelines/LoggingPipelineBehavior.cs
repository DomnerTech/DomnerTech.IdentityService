using Bas24.CommandQuery;
using DomnerTech.IdentityService.Application.Abstractions;
using DomnerTech.IdentityService.Application.Json;
using Microsoft.Extensions.Logging;

namespace DomnerTech.IdentityService.Application.Pipelines;

public class LoggingPipelineBehavior<TRequest, TResponse>(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var requestName = typeof(TRequest).Name;
        if (request is ILogCreator || request is ILogReqCreator)
        {
            logger.LogDebug("Handling {RequestName}: {Request}", requestName, JsonConvert.SerializeObject(request));
        }

        if (request is not ILogCreator && request is not ILogResCreator)
        {
            return await next(cancellationToken);
        }

        var response = await next(cancellationToken);
        logger.LogDebug("Handled {RequestName} with response: {Response}", requestName, JsonConvert.SerializeObject(response));
        return response;
    }
}