namespace AuthService.Application.DTOs;

/// <summary>
/// Request model for user registration.
/// </summary>
public class RegisterUserRequest
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}