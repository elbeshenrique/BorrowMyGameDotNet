using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BorrowMyGameDotNet.Modules.Auth.Domain.Entities;
using BorrowMyGameDotNet.Modules.Auth.Domain.Exceptions;
using BorrowMyGameDotNet.Modules.Auth.Domain.Usecases;
using BorrowMyGameDotNet.Modules.Auth.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BorrowMyGameDotNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserUsecase userUsecase;

        public UserController(IUserUsecase userUsecase)
        {
            this.userUsecase = userUsecase;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginInput loginInput)
        {
            try
            {
                var user = await userUsecase.GetAuthenticatedAsync(loginInput);
                if (user == null)
                {
                    return Unauthorized();
                }

                var token = GenerateUserToken(user);
                return Ok(token);
            }
            catch (InvalidInputException)
            {
                return BadRequest();
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
            catch
            {
                return BadRequest();
            }
        }

        private string GenerateUserToken(User user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecurityInfo.SecurityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, JwtSecurityInfo.Algorithm);

            var claims = new List<Claim>();
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

            var JWT = new JwtSecurityToken(
                issuer: JwtSecurityInfo.Issuer,
                expires: DateTime.Now.AddDays(JwtSecurityInfo.DaysToExpire),
                audience: JwtSecurityInfo.Audience,
                signingCredentials: signingCredentials,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(JWT);
            return token;
        }
    }
}