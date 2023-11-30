using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class TokenService : BaseService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _configuration = configuration;
        }


        public string CreateJWTToken(IdentityUser user, IList<string> roles)
        {
            //create claims details based on the user information
            var claims = new List<Claim>();

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                                    _configuration["Jwt:Issuer"],
                                    _configuration["Jwt:Issuer"],
                                          claims,
                                          expires: DateTime.Now.AddMinutes(120),
                                          signingCredentials: credentials
                                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
