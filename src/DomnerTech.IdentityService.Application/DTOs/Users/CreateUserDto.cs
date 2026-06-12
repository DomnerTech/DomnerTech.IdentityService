namespace DomnerTech.IdentityService.Application.DTOs.Users;

public sealed record CreateUserDto(string Username, string Email, string Password);