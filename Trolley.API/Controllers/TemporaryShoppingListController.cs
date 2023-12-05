using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryShoppingListController : BaseController
    {
        private readonly TemporaryShoppingListService _temporaryShoppingListService;

        public TemporaryShoppingListController(IServiceProvider serviceProvider, TemporaryShoppingListService temporaryShoppingListService) : base(serviceProvider)
        {
            _temporaryShoppingListService = temporaryShoppingListService;
        }

        //Frontend-Integration: Die Logik zur Generierung und Speicherung der eindeutigen Kennung muss im Frontend implementiert werden.
        // POST: /api/TemporaryShoppingList/AddProduct
        [HttpPost("AddProductAndCalculate")]
        public async Task<ActionResult<List<TempMarketCostDto>>> AddProductAndCalculateCostsPerMarket(TempProductToAddDto productToAdd, [FromHeader] string uniqueToken)
        {
            var marketCosts = await _temporaryShoppingListService.AddProductAndCalculateCostsPerMarketAsync(productToAdd, uniqueToken);
            return Ok(marketCosts);
        }



        // GET: /api/TemporaryShoppingList/GetTemporaryShoppingList
        [HttpGet("GetTemporaryShoppingList")]
        public async Task<ActionResult> GetTemporaryListWithCosts([FromHeader] string uniqueToken)
        {
            var (tempList, marketCosts) = await _temporaryShoppingListService.GetTemporaryShoppingListWithCostsAsync(uniqueToken);
            return Ok(new { TempList = tempList, MarketCosts = marketCosts });
        }

    }
}
