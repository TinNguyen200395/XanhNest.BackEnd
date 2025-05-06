using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using XanhNest.BackEndServer.Application.DTOs.Requests;
using XanhNest.BackEndServer.Application.DTOs.Requests.Auth;
using XanhNest.BackEndServer.Application.Interfaces;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly HttpClient _httpClient;

    public AuthController(IAuthService authService, HttpClient httpClient)
    {
        _authService = authService;
        _httpClient = httpClient;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);
        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(new { Message = "User registered successfully" });
    }




}
