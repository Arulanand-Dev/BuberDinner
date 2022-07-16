using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services;
using BuberDinner.Cotracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
           request.Email,
           request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );
        return Ok(response);
    }
}