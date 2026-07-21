using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    public const string SecurityKeyValue = "mysuperdupersecret-mysuperdupersecret";
    public const string Issuer = "mySystem";
    public const string Audience = "myUsers";

    [HttpGet]
    public ActionResult<string> Get()
    {
        return GenerateJsonWebToken(1, "Admin");
    }

    private static string GenerateJsonWebToken(int userId, string userRole)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKeyValue));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, userRole),
            new("UserId", userId.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: Issuer,
            audience: Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
