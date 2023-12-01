using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : BaseController
    {
        private readonly AppUserService _appUserService;
        public AppUserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _appUserService = new AppUserService(serviceProvider);
        }

        // GET: api/AppUser
        // Get all users
        [HttpGet]
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
    }
}
