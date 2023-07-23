using Microsoft.AspNetCore.Mvc;
using User.API.Dtos;
using User.API.Service.IService;

namespace User.API.Controllers.v1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationRequestDto request)
    {
        var result = await _authService.Register(request);
        if (result.Succeeded)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.Login(request);
        if (result.Succeeded)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }

    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(AssignRoleRequestDto request)
    {
        var result = await _authService.AssignRole(request);
        return Ok(result);
    }
}
