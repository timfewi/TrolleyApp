using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Enums;
using Trolley.API.Services;
using System.Threading.Tasks;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        public AuthController(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, TokenService tokenService)
            : base(serviceProvider)
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

            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                var createdUser = await _userManager.FindByNameAsync(registerRequestDto.Username);
                identityResult = await _userManager.AddToRolesAsync(createdUser, registerRequestDto.Roles);

                if (!identityResult.Succeeded)
                {
                    return BadRequest(identityResult.Errors);
                }
            }

            return Ok("User was registered! Please login.");
        }

        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

                if (user == null)
                {
                    return BadRequest("Failed to login");
                }

                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (!checkPasswordResult)
                {
                    return BadRequest("Failed to login");
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (roles == null || !roles.Any())
                {
                    return BadRequest("Failed to login");
                }

                var jwtToken = _tokenService.CreateJWTToken(user, roles.ToList());

                return Ok(new
                {
                    Message = "Login successful",
                    JwtToken = jwtToken
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
