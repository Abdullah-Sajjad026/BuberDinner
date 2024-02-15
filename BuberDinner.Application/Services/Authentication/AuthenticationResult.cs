
namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Token
);