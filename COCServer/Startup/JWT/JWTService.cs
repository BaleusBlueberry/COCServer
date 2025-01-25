using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using COCServer.Controllers;
using DLA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace COCServer.Startup.JWT;
public class JwtService(IConfiguration configuration, UserManager<AppUser> userManager, ILogger<AuthController> logger)
{
    public async Task<string> CreateToken(AppUser user)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ??
                        throw new Exception("Secret key must be set up in app settings");

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var isAdmin = await userManager.IsInRoleAsync(user, "Admin");

        if (isAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(30),
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            signingCredentials: creds
        );
        logger.LogDebug("issuer: " + jwtSettings["Issuer"]);
        logger.LogDebug("Audience: " + jwtSettings["Audience"]);

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);
        logger.LogDebug("Generated JWT Token: " + jwt);
        return jwt;
    }
}