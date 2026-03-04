using System.Threading;
using System.Threading.Tasks;
using AuthService.Application.DTOs;
using AuthService.Application.UseCases;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using Moq;
using Xunit;

namespace AuthService.UnitTests;

public class RegisterUserCommandTests
{
    [Theory]
    [InlineData("Derz", "Admin", "derz@test.com", "Password123!")]
    [InlineData("John", "Doe", "john@test.com", "SecurePass1!")]
    public async Task Register_Should_Create_User_When_Email_Not_Exists(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        userRepositoryMock
            .Setup(r => r.GetByEmailAsync(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        userRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        passwordHasherMock
            .Setup(h => h.Hash(password))
            .Returns("hashed-password");

        var command = new RegisterUserCommand(
            userRepositoryMock.Object,
            passwordHasherMock.Object);

        var request = new RegisterUserRequest
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        // Act
        await command.ExecuteAsync(request);

        // Assert
        userRepositoryMock.Verify(
            r => r.AddAsync(
                It.Is<User>(u =>
                    u.Email == email &&
                    u.FirstName == firstName &&
                    u.LastName == lastName &&
                    u.PasswordHash == "hashed-password"),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Theory]
    [InlineData("existing@test.com")]
    public async Task Register_Should_Throw_When_Email_Already_Exists(
        string email)
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordHasherMock = new Mock<IPasswordHasher>();

        userRepositoryMock
            .Setup(r => r.GetByEmailAsync(email, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Mock<User>().Object); // avoids constructor issues

        var command = new RegisterUserCommand(
            userRepositoryMock.Object,
            passwordHasherMock.Object);

        var request = new RegisterUserRequest
        {
            FirstName = "Test",
            LastName = "User",
            Email = email,
            Password = "Password123!"
        };

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() =>
            command.ExecuteAsync(request));
    }
}