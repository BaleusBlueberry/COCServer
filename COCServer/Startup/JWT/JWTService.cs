using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DLA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace COCServer.Startup.JWT;
public class JwtService(IConfiguration configuration, UserManager<AppUser> userManager)
{
    public async Task<string> CreateToken(AppUser user)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ??
                        throw new Exception("Secret key must be set up in app settings");
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var isAdmin = await userManager.IsInRoleAsync(user, "Admin");

        if (isAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "admin"));
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

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}