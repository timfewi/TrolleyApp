using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Enums;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly AdminService _adminService;
        public AdminController(IServiceProvider serviceProvider, AdminService adminService) : base(serviceProvider)
        {
            _adminService = adminService;
        }

        // GET: api/Admin/GetAllUsers
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _adminService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't find users", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // GET: api/Admin/GetUserRoles
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            try
            {
                var roles = await _adminService.GetUserRolesAsync(userId);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't find roles for user with id {userId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Admin/AddRoleToUser
        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(string userId, string roleName)
        {
            try
            {
                var result = await _adminService.AddRoleToUserAsync(userId, roleName);
                if (result)
                {
                    return Ok($"Role {roleName} added to user with id {userId}");
                }
                else
                {
                    return BadRequest($"Couldn't add role {roleName} to user with id {userId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't add role {roleName} to user with id {userId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Admin/RemoveRoleFromUser
        [HttpPost("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {
            try
            {
                var result = await _adminService.RemoveRoleFromUserAsync(userId, roleName);
                if (result)
                {
                    return Ok($"Role {roleName} removed from user with id {userId}");
                }
                else
                {
                    return BadRequest($"Couldn't remove role {roleName} from user with id {userId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't remove role {roleName} from user with id {userId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Admin/UpdateEmail
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string userId, string newEmail, string newUserName)
        {
            try
            {
                var result = await _adminService.EditUserAsync(userId, newEmail, newUserName);
                if (result)
                {
                    return Ok($"User with id {userId} updated successfully");
                }
                else
                {
                    return BadRequest($"Couldn't update user with id {userId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't update user with id {userId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Admin/DeleteUser
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                var result = await _adminService.DeleteUserAsync(userId);
                if (result)
                {
                    return Ok($"User with id {userId} deleted successfully");
                }
                else
                {
                    return BadRequest($"Couldn't delete user with id {userId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't delete user with id {userId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // POST: api/Admin/ApproveProduct
        [HttpPost("ApproveProducts")]
        public async Task<IActionResult> ApproveProducts()
        {
            var tempProducts = _context.TempProducts.ToList();

            foreach (var tempProduct in tempProducts)
            {
                // Produkt-ID und Markt-ID basierend auf Namen finden oder erstellen
                var marketId = FindOrCreateMarket(tempProduct.MarketName);
                var productId = FindOrCreateProduct(tempProduct);

                // Neues MarketProduct erstellen
                var marketProduct = new MarketProduct
                {
                    MarketId = marketId,
                    ProductId = productId,
                    Price = tempProduct.Price
                    // Weitere Felder nach Bedarf
                };

                _context.MarketProduct.Add(marketProduct);
            }

            await _context.SaveChangesAsync();

            // Temporäre Produkte löschen
            _context.TempProducts.RemoveRange(tempProducts);
            await _context.SaveChangesAsync();

            return Ok("Produkte erfolgreich genehmigt und gespeichert.");
        }

        private int FindOrCreateProduct(TempProduct tempProduct)
        {
            var existingProduct = _context.Products.FirstOrDefault(p =>
                p.Name == tempProduct.ProductName &&
                p.IsOrganic == tempProduct.IsOrganic &&
                p.IsDiscountProduct == tempProduct.IsDiscountProduct);

            if (existingProduct != null)
            {
                return existingProduct.Id;
            }

            var newProduct = new Product
            {
                Name = tempProduct.ProductName,
                IsOrganic = tempProduct.IsOrganic,
                IsDiscountProduct = tempProduct.IsDiscountProduct,
                // Setzen Sie hier weitere relevante Eigenschaften
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return newProduct.Id;
        }


        private int FindOrCreateMarket(string marketName)
        {
            var existingMarket = _context.Markets.FirstOrDefault(m => m.Name == marketName);

            if (existingMarket != null)
            {
                return existingMarket.Id;
            }

            var newMarket = new Market
            {
                Name = marketName,
                MarketCategory = MarketCategory.Supermarket
            };

            _context.Markets.Add(newMarket);
            _context.SaveChanges();

            return newMarket.Id;
        }



    }
}
