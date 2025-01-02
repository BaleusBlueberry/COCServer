using COCServer.DTOs;
using COCServer.DTOs.Extensions;
using COCServer.Startup.JWT;
using DLA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;

namespace COCServer.Controllers;


[Route("API/[controller]")]
[ApiController]
public class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JwtService jwtService, RoleManager<AppRole> roleManager, ILogger<AuthController> logger) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.Users.AnyAsync(p => p.Email == registerDto.Email || p.UserName == registerDto.UserName);

            if (user) return Conflict("User Already Exists");

            var result = await userManager.CreateAsync(registerDto.ToUser(), registerDto.Password);

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

            AppUser user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user is null || user.UserName is null)
            {
                return Unauthorized();
            }

            bool result = await userManager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                await signInManager.SignInAsync(user, isPersistent: true);

                string token = await jwtService.CreateToken(user);

                var roles = await userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    logger.LogDebug(role);
                }

                return Ok(new { token });
            }
            return Unauthorized();
        }
        return BadRequest(ModelState);
    }
}
