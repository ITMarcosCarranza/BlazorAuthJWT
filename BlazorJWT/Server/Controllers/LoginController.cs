using BlazorJWT.Server.Data;
using BlazorJWT.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace BlazorJWT.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsersDB  _dbContext;
        public LoginController(IConfiguration configuration,UsersDB dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _dbContext.UserModels
                                         .Where(x => x.Name == loginModel.UserName)
                                         .FirstOrDefaultAsync();

            if (result is null) return Unauthorized();

            var claims = new[] {
                new Claim(ClaimTypes.Name,result.Name),
                new Claim(ClaimTypes.Role,result.Role)
            } ;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var jwt = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires:DateTime.Now.AddDays(1),
                claims:claims,
                signingCredentials: credentials
                );
            var token =new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new LoginResult {isValid=true,Token=token});
        }
    }
}
