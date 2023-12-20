
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseController
    {
        private readonly JwtTokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUserService _appUserService;
        public AppUserController(IServiceProvider serviceProvider, AppUserService appUserService, UserManager<AppUser> userManager, JwtTokenService tokenService) : base(serviceProvider)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _tokenService = tokenService;
        }


        // GET: api/AppUser/GetAll
        // Get all users
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            try
            {
                var users = await _appUserService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log exception and handle errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/AppUser/Get
        // Get user by id
        [HttpGet("Get")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<AppUser>> GetUserById()
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
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, $"Unauthorized access!");
                return Unauthorized();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"User with not found");
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting user.");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        // PUT: api/AppUser/UpdateEmail
        // Update user email
        [HttpPut]
        [Route("UpdateEmail")]
        [Authorize]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDto updateEmailDto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return BadRequest($"Couldn't find user with id {userId}");
                }

                // Aktualisiere die E-Mail-Adresse des Benutzers
                var result = await _userManager.SetEmailAsync(user, updateEmailDto.NewEmail);
                await _userManager.SetUserNameAsync(user, updateEmailDto.NewEmail);
                if (!result.Succeeded)
                {
                    return BadRequest("Failed to update email");
                }
                _logger.LogInformation($"User with id {userId} updated email to {updateEmailDto.NewEmail}");
                return Ok("Email updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating email");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/AppUser/UpdatePassword
        // Update user password
        [HttpPut]
        [Route("UpdatePassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return BadRequest($"Couldn't find user with id {userId}");
                }

                // Aktualisiere das Passwort des Benutzers
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordDto.OldPassword, updatePasswordDto.NewPassword);
                if (!result.Succeeded)
                {
                    return BadRequest("Failed to update password");
                }
                _logger.LogInformation($"User with id {userId} updated password");
                return Ok("Password updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating password");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/AppUser/Delete
        // Delete user
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    _logger.LogError($"Couldn't find user with id {userId}");
                    return BadRequest($"Couldn't find user with id {userId}");
                }

                // Lösche den Benutzer
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest("Failed to delete user");
                }
                _logger.LogInformation($"User with id {userId} deleted");
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
