using System.ComponentModel.DataAnnotations;

namespace DomnerTech.IdentityService.Application.DTOs;

public record BaseRequest
{
    [Required]
    public Guid UserId { get; set; }
}