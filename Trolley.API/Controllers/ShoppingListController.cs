using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trolley.API.Data;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController
    {
        private readonly ShoppingListService _shoppingListService;
        private readonly ILogger<ShoppingListController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public ShoppingListController(IServiceProvider serviceProvider, ILogger<ShoppingListController> logger,
            ShoppingListService shoppingListService, UserManager<AppUser> userManager) : base(serviceProvider)
        {
            _shoppingListService = shoppingListService;
            _userManager = userManager;
            _logger = logger;
        }

        #region CRUD
        // Post: api/ShoppingList
        [HttpPost]
        [Authorize]
        [Route("Create")]
        public async Task<IActionResult> CreateShoppingList([FromBody] ShoppingListCreateDto createDto)
        {
            var userId = _userManager.GetUserId(User); // Extrahiert die UserId aus dem Authentifizierungstoken
            var shoppingList = await _shoppingListService.CreateShoppingListAsync(userId, createDto);
            return Ok(shoppingList);
        }


        // GET: api/ShoppingList/shoppingListId
        [HttpGet("{shoppingListId}")]
        [Authorize]
        public async Task<IActionResult> GetShoppingList(int shoppingListId)
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                var shoppingListDto = await _shoppingListService.GetShoppingListByIdAsync(userId, shoppingListId);
                var totalCost =
                    await _shoppingListService.CalculateShoppingListCostPerMarketWithProductDetailPrice(shoppingListId,
                        userId);

                if (shoppingListDto == null)
                {
                    return NotFound();
                }

                return Ok(new { ShoppingList = shoppingListDto, TotalCostPerMarket = totalCost });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving shopping list with ID {ShoppingListId}", shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving shopping list");
            }
        }

        // GET: api/ShoppingList
        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllShoppingLists()
        {
            // Benutzer-ID aus dem Authentifizierungskontext extrahieren
            var userId = _userManager.GetUserId(User);

            try
            {
                var shoppingListsDtos = await _shoppingListService.GetAllShoppingListsByUserAsync(userId);
                var totalCostsPerList = new Dictionary<int, Dictionary<string, double>>();

                foreach (var list in shoppingListsDtos)
                {
                    totalCostsPerList[list.Id] = await _shoppingListService.CalculateTotalCostPerMarketAsync(list.Id);
                }

                return Ok(new { ShoppingLists = shoppingListsDtos, TotalCostsPerList = totalCostsPerList });
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung
                _logger.LogError(ex, "Error retrieving shopping lists for user with ID {UserId}", userId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving shopping lists");
            }
        }



        // PUT: api/ShoppingList/{shoppingListId}
        [HttpPut("{shoppingListId}")]
        [Authorize]
        public async Task<IActionResult> UpdateShoppingList(int shoppingListId,
            [FromBody] ShoppingListUpdateDto updateDto)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                var updatedShoppingList = await _shoppingListService.UpdateShoppingListAsync(shoppingListId, userId, updateDto);

                if (updatedShoppingList == null)
                {
                    return NotFound();
                }

                return Ok(updatedShoppingList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shopping list with ID {ShoppingListId}", shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating shopping list");
            }
        }


        // DELETE: api/ShoppingList/{shoppingListId}
        [HttpDelete("{shoppingListId}")]
        [Authorize]
        public async Task<IActionResult> DeleteShoppingList(int shoppingListId)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                await _shoppingListService.DeleteShoppingListAsync(shoppingListId, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting shopping list with ID {ShoppingListId}", shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting shopping list");
            }
        }

        #endregion


        #region Add/Remove Products

        //POST: api/ShoppingList/{shoppingListId}/AddProduct
        [HttpPost("{shoppingListId}/AddProduct")]
        [Authorize]
        public async Task<IActionResult> AddProductToShoppingList(int shoppingListId,
           [FromBody] AddProductToShoppingListDto addProductToShoppingListDto)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                await _shoppingListService.AddProductToShoppingListAsync(
                   shoppingListId,
                    addProductToShoppingListDto.ProductId,
                    addProductToShoppingListDto.Amount,
                    userId);


                var shoppingListCostDto =
                    await _shoppingListService.CalculateShoppingListCostPerMarketWithProductDetailPrice(shoppingListId, userId);

                return Ok(shoppingListCostDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product to shopping list");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding product to shopping list");
            }
        }


        // LIST OF PRODUCTS
        // POST: api/ShoppingList/{shoppingListId}/AddProducts
        [HttpPost("{shoppingListId}/AddProducts")]
        [Authorize]
        public async Task<IActionResult> AddProductsToShoppingList(int shoppingListId, [FromBody] List<ProductToAddDto> products)
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                await _shoppingListService.AddProductsToShoppingListAsync(shoppingListId, products, userId);
                var totalCostPerMarket = await _shoppingListService.GetShoppingListWithMarketTotalPricesAsync(shoppingListId);
                return Ok(new { Message = "Products added successfully.", TotalCostPerMarket = totalCostPerMarket });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding products to shopping list with ID {ShoppingListId}", shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding products to shopping list");
            }
        }


        // DELETE: api/ShoppingList/{shoppingListId}/RemoveProduct/{productId}
        [HttpDelete("{shoppingListId}/RemoveProduct/{productId}")]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromShoppingList(int shoppingListId, int productId)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                await _shoppingListService.RemoveProductFromShoppingListAsync(shoppingListId, productId, userId);
                var shoppingListCostDto = await _shoppingListService.CalculateShoppingListCostPerMarketWithProductDetailPrice(shoppingListId, userId);

                return Ok(shoppingListCostDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing product with ID {ProductId} from shopping list with ID {ShoppingListId}", productId, shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing product from shopping list");
            }
        }


        // PUT: api/ShoppingList/{shoppingListId}/UpdateProductAmount
        [HttpPut("{shoppingListId}/UpdateProductAmount")]
        [Authorize]
        public async Task<IActionResult> UpdateProductAmount(int shoppingListId, [FromBody] ProductAmountUpdateDto productAmountUpdateDto)
        {
            var userId = _userManager.GetUserId(User);
            try
            {
                await _shoppingListService.UpdateProductAmountInShoppingListAsync(shoppingListId, productAmountUpdateDto, userId);
                var totalCostPerMarket = await _shoppingListService.GetShoppingListWithMarketTotalPricesAsync(shoppingListId);
                return Ok(new { Message = "Product amount updated successfully.", TotalCostPerMarket = totalCostPerMarket });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database update error in UpdateProductAmount.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while updating the product amount." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product amount in shopping list with ID {ShoppingListId}", shoppingListId);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Unexpected error occurred." });
            }
        }


        #endregion



    }
}
