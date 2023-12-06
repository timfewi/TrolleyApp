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
    public class TemporaryShoppingListController : BaseController
    {
        private readonly TemporaryShoppingListService _temporaryShoppingListService;
        private readonly UserManager<AppUser> _userManager;

        public TemporaryShoppingListController(IServiceProvider serviceProvider, TemporaryShoppingListService temporaryShoppingListService,
            UserManager<AppUser> userManager) : base(serviceProvider)
        {
            _temporaryShoppingListService = temporaryShoppingListService;
            _userManager = userManager;
        }

        //POST : /api/TemporaryShoppingList/AddProductList
        [HttpPost("AddProductAndCalculateList")]
        public async Task<ActionResult<List<TempMarketCostDto>>> AddProductAndCalculateCostsPerMarket([FromBody] List<TempProductItemDto> productListDto)
        {
            var marketCosts = await _temporaryShoppingListService.AddProductAndCalculateCostsPerMarketAsync(productListDto);
            return Ok(marketCosts);
        }


        //POST : /api/TemporaryShoppingList/ConvertToPermanent
        [HttpPost("ConvertToPermanent")]
        [Authorize]
        public async Task<IActionResult> ConvertTempListToPermanent([FromBody] List<TempProductItemDto> tempListDto)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                var permanentList = await _temporaryShoppingListService.ConvertTemplistToPermanentListAsync(tempListDto, userId);
                return Ok(permanentList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting temporary list to permanent.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error converting list");
            }
        }


    }
}
