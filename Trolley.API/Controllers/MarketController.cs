using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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



    }
}
