namespace DomnerTech.IdentityService.Application.Services;

public interface ICorrelationContext
{
    string CorrelationId { get; }
}