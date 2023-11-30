using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Enums;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;
        public AuthController(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, TokenService tokenService) : base(serviceProvider)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // Füge den benutzerdefinierten User zur Datenbank hinzu
                var customUser = new User
                {
                    IdentityUserId = identityUser.Id
                };
                _context.User.Add(customUser);
                await _context.SaveChangesAsync();

                // Füge Rollen zu diesem IdentityUser hinzu
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    // Hier verwenden wir das identityUser-Objekt
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                    else
                    {
                        return BadRequest(identityResult.Errors);
                    }
                }
            }
            return Ok();
        }




        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    //Roles

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null && roles.Any())
                    {
                        //Create Token
                        var jwtToken = _tokenService.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }

                }
            }
            return BadRequest("Invalid login attempt.");

        }

    }


}
