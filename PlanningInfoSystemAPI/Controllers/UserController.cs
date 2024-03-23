
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlanningInfoSystemAPI.Configurations;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens;

namespace PlanningInfoSystemAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    //private readonly JwtConfig _jwtconfig;

    public UserController(
        DataContext context,
        UserManager<IdentityUser> userManager,        
        IConfiguration configuration
        //JwtConfig jwtconfig
        )
    {
        _userManager = userManager;
        _configuration = configuration;
        //_jwtconfig = jwtconfig;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserTblDto data)
    {
        // Validate the incoming request
        if (ModelState.IsValid)
        {
            // We need to check if the email already exist
            var user_exist = await _userManager.FindByEmailAsync(data.Email);

            if (user_exist != null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "Email already exist"
                    }
                });
            }

            // create a user
            var new_user = new IdentityUser()
            {
                Email = data.Email,
                UserName = data.Email
            };

            var is_created = await _userManager.CreateAsync(new_user, data.Password);

            if (is_created.Succeeded)
            {
                // Generate the token
                var token = GenerateJwtToken(new_user);

                return Ok(new AuthResult()
                {
                    Result = true,
                    Token = token
                });
            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Server Error"
                },
                Result = false
            });
        }

        return BadRequest();
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        //var key = Encoding.UTF8.GetBytes(_jwtconfig.Secret);
        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, value:user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
            }),

            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }
}
