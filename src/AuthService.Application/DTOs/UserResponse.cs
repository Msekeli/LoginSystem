namespace AuthService.Application.DTOs;

/// <summary>
/// Returned when fetching user details.
/// </summary>
public class UserResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}