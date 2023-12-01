﻿using Microsoft.AspNetCore.Mvc;
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

        public ShoppingListController(IServiceProvider serviceProvider, ILogger<ShoppingListController> logger, ShoppingListService shoppingListService) : base(serviceProvider)
        {
            _shoppingListService = shoppingListService;
            _logger = logger;
        }

        // Post: api/ShoppingList
        // Create a shopping list
        [HttpPost]
        public async Task<ActionResult<ShoppingListCreateDto>> CreateShoppingList(ShoppingListCreateDto shoppingListCreateDto)
        {
            try
            {
                var shoppingList = _mapper.Map<ShoppingList>(shoppingListCreateDto);
                var createdList = await _shoppingListService.CreateShoppingListAsync(shoppingList);
                var shoppingListReadDto = _mapper.Map<ShoppingListReadDto>(createdList);

                _logger.LogInformation($"Shopping list with id: {shoppingListReadDto.Id} was created.");

                return CreatedAtAction(nameof(GetShoppingListById),
                    new { id = shoppingListReadDto.Id },
                    shoppingListReadDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        // GET: api/ShoppingList/{id}
        // Get a shopping list by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingListReadDto>> GetShoppingListById(int id)
        {
            try
            {
                var shoppingList = await _shoppingListService.GetShoppingListByIdAsync(id);
                if (shoppingList == null)
                {
                    return NotFound();
                }
                var shoppingListReadDto = _mapper.Map<ShoppingListReadDto>(shoppingList);
                return Ok(shoppingList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ShoppingList/{id}
        // Update a shopping list
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ShoppingListUpdateDto>> UpdateShoppingList(int id, ShoppingListUpdateDto shoppingListUpdateDto)
        {
            try
            {
                if (id != shoppingListUpdateDto.Id)
                {
                    return BadRequest();
                }

                var shoppingList = _mapper.Map<ShoppingList>(shoppingListUpdateDto);
                var updatedList = await _shoppingListService.UpdateShoppingListAsync(shoppingList);
                var shoppingListReadDto = _mapper.Map<ShoppingListReadDto>(updatedList);
                return Ok(shoppingListReadDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ShoppingList/{id}
        // Delete a shopping list
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteShoppingList(int id)
        {
            try
            {
                await _shoppingListService.DeleteShoppingListAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }



        //TODO: CHANGE PARAMETER TO ONLY DTO
        // POST: api/ShoppingList/{id}/AddProduct
        // Add a product to a shopping list
        [HttpPost]
        [Route("{shoppingListId:int}/AddProduct")]
        public async Task<ActionResult> AddProductToShoppingList(int shoppingListId,
            AddProductToShoppingListDto addProductToShoppingListDto)
        {
            try
            {
                var result = await _shoppingListService.AddProductToShoppingListAsync(
                    shoppingListId,
                    addProductToShoppingListDto.ProductId,
                    addProductToShoppingListDto.Amount);


                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/Calculate")]
        public async Task<ActionResult<ShoppingListReadDto>> GetShoppingListWithCalculations([FromRoute] int id, [FromQuery] string userId)
        {
            try
            {
                var requestDto = new ShoppingListCalculationRequestDto
                {
                    ShoppingListId = id,
                    UserId = userId
                };

                var shoppingList = await _shoppingListService.GetShoppingListWithCalculationsAsync(requestDto);
                if (shoppingList == null)
                {
                    return NotFound();
                }

                var shoppingListReadDto = _mapper.Map<ShoppingListReadDto>(shoppingList);
                return Ok(shoppingListReadDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/CheapestMarket")]
        public async Task<ActionResult> GetCheapestMarketForShoppingList([FromRoute] int id, [FromQuery] string userId)
        {
            try
            {
                var requestDto = new CheapestMarketCalculationRequestDto
                {
                    ShoppingListId = id,
                    UserId = userId
                };

                var cheapestMarket = await _shoppingListService.CalculateCheapestMarketForShoppingListAsync(requestDto);

                return Ok(new
                {
                    CheapestMarket = cheapestMarket.Key,
                    TotalPrice = cheapestMarket.Value
                });
            }
            catch (KeyNotFoundException knfEx)
            {
                _logger.LogError(knfEx, knfEx.Message);
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{shoppingListId:int}/CheapestShoppingListOverall")]
        public async Task<ActionResult<ShoppingListDetailDto>> GetShoppingListDetailCheapestOverall(int shoppingListId)
        {
            try
            {
                var details = await _shoppingListService.GetShoppingListDetailsAsync(shoppingListId);
                return Ok(details);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting shopping list details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }


        [HttpGet]
        [Route("{shoppingListId:int}/CheapestShoppingListPerMarket")]
        public async Task<ActionResult<ShoppingListDetailDto>> GetShoppingListDetailsCheapestMarket(int shoppingListId)
        {
            try
            {
                var details = await _shoppingListService.GetConsistentMarketShoppingListDetailsAsync(shoppingListId);
                return Ok(details);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting shopping list details.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }
    }
}
