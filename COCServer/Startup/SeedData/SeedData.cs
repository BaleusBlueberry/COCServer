using DLA.Models;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

namespace COCServer.Startup.SeedData;

public class Seeder
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ILogger<Seeder> _logger;
    private readonly IConfiguration _configuration;

    public Seeder(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ILogger<Seeder> logger, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
        _configuration = configuration;
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

        var adminConfig = _configuration.GetSection("AdminAcc") ?? throw new InvalidOperationException("AdminAcc Not found");
        string adminEmail = adminConfig["Email"] ?? throw new InvalidOperationException("Email Of AdminAcc Not found");
        string adminUserName = adminConfig["UserName"] ?? throw new InvalidOperationException("UserName Of AdminAcc Not found");
        string adminPassword = adminConfig["Password"] ?? throw new InvalidOperationException("Password Of AdminAcc Not found");

        var adminUser = await _userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = adminUserName,
                Email = adminEmail
            };
            var result = await _userManager.CreateAsync(adminUser, adminPassword);

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

