using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Enums;
using Trolley.API.Services;
using System.Threading.Tasks;
using iText.Kernel.Pdf.Tagutils;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtTokenService _tokenService;

        public AuthController(IServiceProvider serviceProvider, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, JwtTokenService tokenService)
            : base(serviceProvider)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            // Überprüfen, ob der Benutzer bereits existiert
            var existingUser = await _userManager.FindByNameAsync(registerRequestDto.Username);
            if (existingUser != null)
            {
                return BadRequest("Ein Benutzer mit diesem Benutzernamen oder E-Mail existiert bereits.");
            }

            var appUser = new AppUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(appUser, registerRequestDto.Password);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            // Benutzer erneut abrufen, um Anhängeprobleme zu vermeiden
            var newUser = await _userManager.FindByIdAsync(appUser.Id);
            if (newUser == null)
            {
                return BadRequest("Benutzer konnte nach der Erstellung nicht gefunden werden.");
            }

            // Automatisch die Rolle "User" zuweisen
            var defaultRole = "User";
            var roleResult = await _userManager.AddToRoleAsync(newUser, defaultRole);
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            var jwtToken = _tokenService.CreateJWTToken(appUser);

            return Ok(new
            {
                Message = "Registration successful",
                JwtToken = $"Bearer {jwtToken}"
            });

            return Ok("Benutzer erfolgreich registriert. Bitte einloggen.");
        }


        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName);

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
                    JwtToken = $"Bearer {jwtToken}"
                    //JwtToken = jwtToken
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to login");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
