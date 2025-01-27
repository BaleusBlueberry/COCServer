using COCServer.DTOs;
using COCServer.DTOs.Extensions;
using COCServer.Startup.JWT;
using DLA.Models;
using DLA.Models.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
using System.Security.Claims;

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

                return Ok(new { token, roles });
            }
            return Unauthorized();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("Update")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto updateDto)
    {
        if (ModelState.IsValid)
        {
            // Get the currently logged-in user
            AppUser? currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized("User not authenticated.");

            // Check if the current user is an admin
            var isAdmin = await userManager.IsInRoleAsync(currentUser, "Admin");

            // Ensure the user can only update their own account unless they are an admin
            if (currentUser.Id.ToString() != updateDto.UserId && !isAdmin)
            {
                return Forbid("You are not authorized to update this user.");
            }

            AppUser? userToUpdate = isAdmin ? await userManager.FindByIdAsync(updateDto.UserId) : currentUser;


            if (userToUpdate == null) return NotFound("User not found.");

            // Update email user
            userToUpdate.Email = updateDto.Email ?? userToUpdate.Email;
            userToUpdate.UserName = updateDto.UserName ?? userToUpdate.UserName;


            // Handle password updates if provided
            if (!string.IsNullOrEmpty(updateDto.NewPassword))
            {
                // Verify current password if the updater is not an admin
                if (!isAdmin)
                {
                    if (!string.IsNullOrEmpty(updateDto.CurrentPassword)) return BadRequest("Current password Not Provided");

                    var passwordCheck = await signInManager.CheckPasswordSignInAsync(currentUser, updateDto.CurrentPassword, false);
                    if (!passwordCheck.Succeeded)
                    {
                        return Unauthorized("Current password is incorrect.");
                    }
                }

                var resetToken = await userManager.GeneratePasswordResetTokenAsync(userToUpdate);
                var passwordUpdateResult = await userManager.ResetPasswordAsync(userToUpdate, resetToken, updateDto.NewPassword);

                if (!passwordUpdateResult.Succeeded)
                {
                    return BadRequest(passwordUpdateResult.Errors);
                }
            }

            var result = await userManager.UpdateAsync(userToUpdate);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(userToUpdate, isPersistent: true);

                string token = await jwtService.CreateToken(userToUpdate);

                var roles = await userManager.GetRolesAsync(userToUpdate);

                foreach (var role in roles)
                {
                    logger.LogDebug(role);
                }

                return Ok(new { token, roles });

            }

            return BadRequest(result.Errors);
        }
        return BadRequest(ModelState);
    }

    [HttpPut("favorites/update")]
    [Authorize]
    public async Task<IActionResult> UpdateFavorites([FromBody] UpdateFavorites updateDto)
    {
        if (ModelState.IsValid)
        {
            AppUser? currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized("User not authenticated.");

            // Check if the current user is an admin
            var isAdmin = await userManager.IsInRoleAsync(currentUser, "Admin");

            // Ensure the user can only update their own account unless they are an admin
            if (currentUser.Id.ToString() != updateDto.UserId && !isAdmin)
            {
                return Forbid("You are not authorized to update this user.");
            }

            AppUser? userToUpdate = isAdmin ? await userManager.FindByIdAsync(updateDto.UserId) : currentUser;
            if (userToUpdate == null) return NotFound("User not found.");

            // Update email user
            userToUpdate.FavoriteBuildings = updateDto.FavoriteBuildings ?? userToUpdate.FavoriteBuildings;
            userToUpdate.FavoriteTownHalls = updateDto.FavoriteTownHalls ?? userToUpdate.FavoriteTownHalls;

            var result = await userManager.UpdateAsync(userToUpdate);
            if (result.Succeeded)
            {
                return Ok("User updated successfully.");
            }

            return BadRequest(result.Errors);
        }
        return BadRequest(ModelState);
    }

    [HttpGet("favorites/{id}")]
    [Authorize]
    public async Task<IActionResult> GetFavorite(string id)
    {

        if (string.IsNullOrWhiteSpace(id)) return new BadRequestObjectResult("ID cannot be null or empty.");

        AppUser? currentUser = await userManager.GetUserAsync(User);
        if (currentUser == null) return Unauthorized("User not authenticated.");

        var isAdmin = await userManager.IsInRoleAsync(currentUser, "Admin");

        // Ensure the user can only get their own account unless they are an admin
        if (currentUser.Id.ToString() != id && !isAdmin)
        {
            return Forbid("You are not authorized to update this user.");
        }

        var user = await userManager.FindByIdAsync(id);

        if (user == null) return new NotFoundObjectResult($"user not found with ID: {id}.");

        return Ok(user.ToFavorites());

    }


    [HttpGet("getUser/{id}")]
    [Authorize]
    public async Task<IActionResult> getUserById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return new BadRequestObjectResult("ID cannot be null or empty.");

        var user = await userManager.FindByIdAsync(id);

        if (user == null) return new NotFoundObjectResult($"user not found with ID: {id}.");

        UpdateUserDto userToReturn = new UpdateUserDto
        {
            UserId = user.Id.ToString(),
            Email = user.Email,
            UserName = user.UserName,
            NewPassword = null,
            CurrentPassword = null
        };

        return new OkObjectResult(userToReturn);
    }
}

