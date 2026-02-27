using AuthService.Domain.Entities;

namespace AuthService.Application.Interfaces;

/// <summary>
/// Abstraction for token generation (e.g., JWT).
/// Implemented in Infrastructure.
/// </summary>
public interface ITokenService
{
    string GenerateToken(User user);
}