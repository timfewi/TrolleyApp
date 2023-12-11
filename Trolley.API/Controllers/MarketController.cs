using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarketController : BaseController
    {
        private readonly MarketService _marketService;
        private readonly UserManager<AppUser> _userManager;
        public MarketController(IServiceProvider serviceProvider, UserManager<AppUser> userManager, MarketService marketService) : base(serviceProvider)
        {
            _userManager = userManager;
            _marketService = marketService;
        }



        // POST: api/Markets/Block
        [HttpPost("Block")]
        public async Task<IActionResult> BlockMarket([FromBody] BlockUnblockMarketDto dto)
        {
            try
            {
                await _marketService.BlockMarketAsync(dto.UserId, dto.MarketId);
                return Ok("Market blocked successfully.");
            }
            catch (Exception ex)
            {
                // Log exception and handle errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Markets/Unblock
        [HttpPost("Unblock")]
        [Authorize]
        public async Task<IActionResult> UnblockMarket([FromBody] BlockUnblockMarketDto dto)
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

                await _marketService.UnblockMarketAsync(dto.UserId, dto.MarketId);
                return Ok("Market unblocked successfully.");
            }
            catch (Exception ex)
            {
                // Log exception and handle errors
                _logger.LogError($"Couldn't unblock market with id {dto.MarketId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Markets/GetAll
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBlockedMarkets(string userId)
        {
            try
            {
                var markets = await _marketService.GetBlockedMarketsForUserAsync(userId);
                return Ok(markets);
            }
            catch (Exception ex)
            {
                // Log exception and handle errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
