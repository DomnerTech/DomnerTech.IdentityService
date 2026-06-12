using DomnerTech.IdentityService.Application.Constants;
using Microsoft.AspNetCore.Http;
using Mobile.CleanArchProjectTemplate.Application.Services;

namespace DomnerTech.IdentityService.Infrastructure.Services;

public sealed class CorrelationContext(IHttpContextAccessor accessor) : ICorrelationContext
{
    public string CorrelationId =>
        accessor.HttpContext?.Items[HeaderConstants.CorrelationContextKey]?.ToString()
        ?? "N/A";
}