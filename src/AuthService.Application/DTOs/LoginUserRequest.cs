namespace AuthService.Application.DTOs;

/// <summary>
/// Request model for login.
/// </summary>
public class LoginUserRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}