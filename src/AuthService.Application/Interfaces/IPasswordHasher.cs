namespace AuthService.Application.Interfaces;

/// <summary>
/// Abstraction for password hashing.
/// Implemented in Infrastructure.
/// </summary>
public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}