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
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;
        public AuthController(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, TokenService tokenService) : base(serviceProvider)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        // POST: api/Auth/Register
        // Register a new user
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, registerDto.Role.ToString());
                    return Ok(new { Message = "User registered successfully" });
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        // POST: api/Auth/Login
        // Login a user
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = _tokenService.CreateJWTToken(new User
                    {
                        Email = user.Email,
                        Role = Enum.Parse<UserRoles>(roles.FirstOrDefault())
                    });

                    return Ok(new LoginResponseDto { JwtToken = token });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


    }


}
