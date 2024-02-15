using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="register"></param>
    /// <response code="201">Returns the newly created user response</response>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AuthenticationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public IActionResult Register([FromBody] RegisterRequest register)
    {

        var authResult = _authenticationService.Register(
            register.Email,
            register.FirstName,
            register.LastName,
            register.Password
        );

        var authenticationResponse = new AuthenticationResponse(
            authResult.Id,
            authResult.Email,
            authResult.FirstName,
            authResult.LastName,
            authResult.Token
        );

        return Ok(authenticationResponse);
    }


    /// <summary>
    /// Logs in the user
    /// </summary>
    /// <param name="login">Login Body</param>
    /// <response code="200">Returns the logged in user response</response>
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponse))]

    [HttpPost("login")]
    public IActionResult Login(LoginRequest login)
    {
        var authResult = _authenticationService.Login(
          login.Email,
          login.Password
      );

        var authenticationResponse = new AuthenticationResponse(
            authResult.Id,
            authResult.Email,
            authResult.FirstName,
            authResult.LastName,
            authResult.Token
        );

        return Ok(authenticationResponse);
    }

}
