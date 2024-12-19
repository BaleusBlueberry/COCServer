using COCServer.DTOs;
using COCServer.DTOs.Extensions;
using COCServer.Startup.JWT;
using DLA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COCServer.Controllers;


[Route("API/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<AppRole> roleManager;
    private readonly JwtService jwtService;

    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _userManager.CreateAsync(registerDto.ToUser(), registerDto.Password);

            if (result.Succeeded)
            {
                return Ok("User created!");
            }
            return BadRequest(result.Errors);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {

            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null || user.UserName is null)
            {
                return Unauthorized();
            }

            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);

                string token = await jwtService.CreateToken(user);

                return Ok(new { token });
            }
            return Unauthorized();
        }
        return BadRequest(ModelState);
    }
}
