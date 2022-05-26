using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using testDemo.Dto.Auth;
using testDemo.Models.Auth;

namespace testDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.UserName == "admin@com" && user.Password == "admin123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConstants.SigningKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Moderator")
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: TokenConstants.Issuer,
                    audience: TokenConstants.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(TokenConstants.ExpiryInMinutes),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
