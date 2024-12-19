using DLA.Models;
using Microsoft.AspNetCore.Identity;

namespace COCServer.Startup.Seeder;

public class Seeder
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ILogger<Seeder> _logger;

    public Seeder(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ILogger<Seeder> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task SeedRolesAndUsersAsync()
    {
        string[] roles = { "Admin" };

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var roleResult = await _roleManager.CreateAsync(new AppRole { Name = role });
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"Role '{role}' created successfully.");
                }
                else
                {
                    _logger.LogError($"Failed to create role '{role}': {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                }
            }
        }

        var adminUser = await _userManager.FindByEmailAsync("admin@example.com");
        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = "admin",
                Email = "admin@example.com"
            };
            var result = await _userManager.CreateAsync(adminUser, "Admin@123");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
                _logger.LogInformation("Admin user created and assigned to 'Admin' role.");
            }
            else
            {
                _logger.LogError("Failed to create admin user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            _logger.LogInformation("Admin user already exists.");
        }
    }
}

