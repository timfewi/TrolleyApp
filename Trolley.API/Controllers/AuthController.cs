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

        public AuthController(IServiceProvider serviceProvider, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, JwtTokenService tokenService)
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
                JwtToken = $"Bearer {jwtToken}",
                User = new
                {
                    newUser.Id,
                    newUser.Email,
                    role = defaultRole
                }
            });

            return Ok("Benutzer erfolgreich registriert. Bitte einloggen.");
        }


        // POST: /api/Auth/Login
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "User not found");
                }

                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (!checkPasswordResult)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Failed to Login");
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (roles == null || !roles.Any())
                {
                    return BadRequest("Failed to login");
                }

                var jwtToken = _tokenService.CreateJWTToken(user, roles.ToList());

                return Ok(new
                {
                    JwtToken = $"Bearer {jwtToken}",
                    user = new
                    {
                        user.Id,
                        user.Email,
                        role = roles[0]
                    }
                    //JwtToken = jwtToken
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to login");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: /api/Auth
        // Updates the jwt token and outputs the user data of the logged in user
        [HttpGet]
        [Route("Get")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserData()
        {
            try
            {
                // Extrahiere Benutzer-ID aus dem JWT-Token
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("Invalid token");
                }

                // Benutzerdaten aus der Datenbank abrufen
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Rollen des Benutzers abrufen
                var roles = await _userManager.GetRolesAsync(user);

                // Neues JWT-Token erstellen
                var jwtToken = _tokenService.CreateJWTToken(user, roles.ToList());

                // Antwort zusammenstellen
                return StatusCode(StatusCodes.Status200OK, new
                {
                    JwtToken = $"Bearer {jwtToken}",
                    user = new
                    {
                        user.Id,
                        user.Email,
                        Role = roles[0],
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get user data");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}