namespace AuthService.Application.DTOs;

/// <summary>
/// Returned after successful login.
/// </summary>
public class AuthResponse
{
    public string Token { get; init; } = string.Empty;
}