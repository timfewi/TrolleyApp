using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/AppUser/GetAllUsersWithRoles
        // Get all users with roles
        [HttpGet("GetAllUsersWithRoles")]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            try
            {
                var usersWithRoles = await _adminService.GetAllUsersWithRolesAsync();
                return Ok(usersWithRoles);
            }
            catch (Exception ex)
            {
                // Log exception and handle errors
                _logger.LogError($"Couldn't find users with roles", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRole([FromBody] UserRoleUpdateDto userRoleUpdate)
        {
            try
            {
                var result = await _adminService.UpdateUserRolesAsync(userRoleUpdate.UserId, new List<string> { userRoleUpdate.RoleName });

                if (result)
                {
                    return Ok($"Role for user with id {userRoleUpdate.UserId} updated successfully");
                }
                else
                {
                    return NotFound($"Couldn't find user with id {userRoleUpdate.UserId} or role name {userRoleUpdate.RoleName}");
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Couldn't find user with id {userRoleUpdate.UserId}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, $"Concurrency issue encountered while updating role for user {userRoleUpdate.UserId}");
                return Conflict($"Concurrency issue: Couldn't update role for user with id {userRoleUpdate.UserId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Couldn't update role for user with id {userRoleUpdate.UserId}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
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

        // DELETE: api/Admin/DeleteTempProducts
        [HttpDelete("DeleteTempProducts")]
        public async Task<IActionResult> DeleteTempProducts()
        {
            try
            {
                var tempProducts = _context.TempCsvUploads.ToList();
                _context.TempCsvUploads.RemoveRange(tempProducts);
                await _context.SaveChangesAsync();
                return Ok($"TempProducts deTempCsvUploadsleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't delete TempProducts", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Admin/GetTempProducts
        [HttpGet("GetTempProducts")]
        public async Task<IActionResult> GetTempProducts()
        {
            try
            {
                var tempProducts = _context.TempCsvUploads.ToList();
                return Ok(tempProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't find TempProducts", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // GET: api/Admin/Get1TempProduct
        [HttpGet("Get1TempProduct")]
        public async Task<IActionResult> Get1TempProduct(int tempProductId)
        {
            try
            {
                var tempProduct = _context.TempCsvUploads.FirstOrDefault(tp => tp.Id == tempProductId);
                if (tempProduct == null)
                {
                    _logger.LogError($"TempProduct with id {tempProductId} not found");
                    return NotFound($"TempProduct with id {tempProductId} not found");
                }
                // Oder DTO verwenden mit beliebigen Feldern
                return Ok(tempProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't find TempProduct with id {tempProductId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // POST: api/Admin/Approve1Product
        [HttpPost("Approve1Product")]
        public async Task<IActionResult> Approve1Product(int tempProductId)
        {
            try
            {
                var tempProduct = _context.TempCsvUploads.FirstOrDefault(tp => tp.Id == tempProductId);
                if (tempProduct == null)
                {
                    _logger.LogError($"TempProduct with id {tempProductId} not found");
                    return NotFound($"TempProduct with id {tempProductId} not found");
                }

                // Produkt-ID und Markt-ID basierend auf Namen finden oder erstellen
                var marketId = FindOrCreateMarket(tempProduct.MarketName);
                var productId = FindOrCreateProduct(tempProduct);

                var existingMarketProduct = _context.MarketProduct
                    .FirstOrDefault(mp => mp.MarketId == marketId && mp.ProductId == productId);

                if (existingMarketProduct == null)
                {
                    // Neues MarketProduct erstellen
                    var marketProduct = new MarketProduct
                    {
                        MarketId = marketId,
                        ProductId = productId,
                        Price = tempProduct.Price
                    };

                    _context.MarketProduct.Add(marketProduct);
                }
                else
                {
                    // MarketProduct aktualisieren
                    existingMarketProduct.Price = tempProduct.Price;
                }
                await _context.SaveChangesAsync();

                // Temporäres Produkt löschen
                _context.TempCsvUploads.Remove(tempProduct);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Produkt erfolgreich genehmigt und gespeichert.",
                    ApprovedProduct = new
                    {
                        MarketName = tempProduct.MarketName,
                        ProductName = tempProduct.ProductName,
                        Price = tempProduct.Price
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't approve product with id {tempProductId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Admin/ApproveProduct
        [HttpPost("ApproveProducts")]
        public async Task<IActionResult> ApproveProducts()
        {
            var tempProducts = _context.TempCsvUploads.ToList();

            foreach (var tempProduct in tempProducts)
            {
                // Produkt-ID und Markt-ID basierend auf Namen finden oder erstellen
                var marketId = FindOrCreateMarket(tempProduct.MarketName);
                var productId = FindOrCreateProduct(tempProduct);

                var existingMarketProduct = _context.MarketProduct
                    .FirstOrDefault(mp => mp.MarketId == marketId && mp.ProductId == productId);

                if (existingMarketProduct == null)
                {
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
                else
                {
                    // MarketProduct aktualisieren
                    existingMarketProduct.Price = tempProduct.Price;
                    // Weitere Felder nach Bedarf
                }
                await _context.SaveChangesAsync();
            }


            // Temporäre Produkte löschen
            _context.TempCsvUploads.RemoveRange(tempProducts);
            await _context.SaveChangesAsync();

            return Ok("Produkte erfolgreich genehmigt und gespeichert.");
        }


        // DELETE: api/Admin/Remove1TempProduct
        [HttpDelete("Remove1TempProduct")]
        public async Task<IActionResult> Remove1TempProduct(int tempProductId)
        {
            try
            {
                var tempProduct = _context.TempCsvUploads.FirstOrDefault(tp => tp.Id == tempProductId);
                if (tempProduct == null)
                {
                    _logger.LogError($"TempProduct with id {tempProductId} not found");
                    return NotFound($"TempProduct with id {tempProductId} not found");
                }

                _context.TempCsvUploads.Remove(tempProduct);
                await _context.SaveChangesAsync();

                return Ok($"TempProduct with id {tempProductId} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Couldn't delete TempProduct with id {tempProductId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        private int FindOrCreateProduct(TempCsvUpload tempProduct)
        {
            var existingProduct = _context.Products.FirstOrDefault(p =>
                p.Name == tempProduct.ProductName &&
                p.IsOrganic == tempProduct.IsOrganic &&
                p.IsDiscountProduct == tempProduct.IsDiscountProduct);

            if (existingProduct != null)
            {
                return existingProduct.Id;
            }

            // Überprüfen, ob die Kategorie existiert
            var category = _context.ProductCategories
                .FirstOrDefault(c => c.Id == tempProduct.ProductCategoryId);

            // Falls die Kategorie nicht existiert, Standardkategorie zuweisen
            if (category == null)
            {
                category = _context.ProductCategories.FirstOrDefault(c => c.Name == "Standardkategorie");
                if (category == null)
                {
                    // Neue Standardkategorie erstellen, falls noch nicht vorhanden
                    category = new ProductCategory { Name = "Standardkategorie" };
                    _context.ProductCategories.Add(category);
                    _context.SaveChanges();
                }
            }

            var newProduct = new Product
            {
                Name = tempProduct.ProductName,
                IsOrganic = tempProduct.IsOrganic,
                IsDiscountProduct = tempProduct.IsDiscountProduct,
                IconName = tempProduct.IconName,
                ProductCategoryId = category.Id
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
