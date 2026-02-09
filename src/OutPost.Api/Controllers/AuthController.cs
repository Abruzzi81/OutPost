using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OutPost.Application.DTOs;
using Microsoft.CodeAnalysis.Operations;
using OutPost.Domain.Entities;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        // Sprawdzanie hasła
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            // Tworzenie listy uprawnień (Claims)
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Dodawanie ról do tokena
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            // Generowanie klucza na podstawie sekretu z Program.cs
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TwójBardzoDługiSekretnyKlucz123!"));

            var token = new JwtSecurityToken(
                issuer: "TwójSystem",
                audience: "TwójSystem",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }
}
