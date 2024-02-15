
namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            Email,
            "firstName",
            "lastName",
            "token here"
    );

    }

    public AuthenticationResult Register(string Email, string FirstName, string LastName, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            Email,
            FirstName, LastName,
            "token here"
        );
    }
}