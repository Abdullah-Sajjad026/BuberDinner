namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string Email, string Password);

    AuthenticationResult Register(string Email, string FirstName, string LastName, string Password);
}