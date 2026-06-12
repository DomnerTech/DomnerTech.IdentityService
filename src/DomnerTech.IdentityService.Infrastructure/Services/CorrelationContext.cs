using DomnerTech.IdentityService.Application.Constants;
using DomnerTech.IdentityService.Application.Services;
using Microsoft.AspNetCore.Http;

namespace DomnerTech.IdentityService.Infrastructure.Services;

public sealed class CorrelationContext(IHttpContextAccessor accessor) : ICorrelationContext
{
    public string CorrelationId =>
        accessor.HttpContext?.Items[HeaderConstants.CorrelationContextKey]?.ToString()
        ?? "N/A";
}