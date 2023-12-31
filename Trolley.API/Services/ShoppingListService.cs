﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;
using Trolley.API.Data;
using Trolley.API.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient.DataClassification;

namespace Trolley.API.Services
{
    public class ShoppingListService : BaseService
    {

        private readonly MarketService _marketService;
        private readonly ILogger<ShoppingListService> _logger;
        public ShoppingListService(IServiceProvider serviceProvider, MarketService marketService) : base(serviceProvider)
        {
            _marketService = marketService;
            _logger = serviceProvider.GetRequiredService<ILogger<ShoppingListService>>();
        }

        #region CRUD Operations

        //CREATE SHOPPING LIST
        public async Task<ShoppingListReadDto> CreateShoppingListAsync(string userId, ShoppingListCreateDto createDto)
        {
            var shoppingList = new ShoppingList
            {

                Name = createDto.Name,

            };

            var userShoppingList = new UserShoppingList
            {
                AppUserId = userId,
                ShoppingList = shoppingList
            };

            _context.UserShoppingLists.Add(userShoppingList);
            await _context.SaveChangesAsync();

            return _mapper.Map<ShoppingListReadDto>(shoppingList);
        }

        //GET SHOPPING LIST BY ID
        public async Task<ShoppingListReadDto> GetShoppingListByIdAsync(string userId, int shoppingListId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {

                throw new KeyNotFoundException("Shopping list not found.");
            }

            return _mapper.Map<ShoppingListReadDto>(shoppingList);
        }

        //GET ALL SHOPPING LISTS
        public async Task<IEnumerable<ShoppingListGetAllDto>> GetAllShoppingListsByUserAsync(string userId)
        {
            // Zuerst die ShoppingList-Instanzen mit den nötigen Includes laden
            var shoppingListEntities = await _context.UserShoppingLists
                .Where(usl => usl.AppUserId == userId)
                .Select(usl => usl.ShoppingListId)
                .ToListAsync();

            var shoppingLists = await _context.ShoppingLists
                .Where(sl => shoppingListEntities.Contains(sl.Id))
                .Include(sl => sl.ProductShoppingLists)
                .ThenInclude(psl => psl.Product)
                .ToListAsync();

            var userBlockedMarkets = await _marketService.GetBlockedMarketsForUserAsync(userId);

            // ShoppingList-Entitäten in DTOs umwandeln
            var shoppingListsDtos = shoppingLists.Select(sl =>
            {
                var costPerMarket = CalculateCostPerMarket(sl, userBlockedMarkets).Result;

                return new ShoppingListGetAllDto
                {
                    Id = sl.Id,
                    Name = sl.Name,
                    CostPerMarket = costPerMarket,
                    Items = sl.ProductShoppingLists.Select(psl => new ProductItemDto
                    {
                        ProductId = psl.ProductId,
                        Amount = psl.Amount
                    }).ToList(),
                    DateCreated = sl.DateCreated,
                    DateModified = sl.DateModified
                };
            });

            return shoppingListsDtos;
        }





        // UPDATE SHOPPING LIST
        public async Task<ShoppingListReadDto> UpdateShoppingListAsync(int shoppingListId, string userId, ShoppingListUpdateDto updateDto)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            shoppingList.Name = updateDto.Name;

            _context.ShoppingLists.Update(shoppingList);
            await _context.SaveChangesAsync();

            return _mapper.Map<ShoppingListReadDto>(shoppingList);
        }


        // DELETE SHOPPING LIST
        public async Task DeleteShoppingListAsync(int shoppingListId, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl =>
                    sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();
        }

        #endregion


        #region Add/Remove/Update Products on Shoppinglist

        // ADD PRODUCT TO SHOPPING LIST
        public async Task AddProductToShoppingListAsync(int shoppingListId, int productId, int amount, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (amount <= 0)
            {
                throw new ArgumentException("Amount of Product must be greater than 0.");
            }

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            var productShoppingList = new ProductShoppingList
            {
                ProductId = productId,
                ShoppingListId = shoppingListId,
                Amount = amount
            };

            _context.ProductShoppingLists.Add(productShoppingList);
            await _context.SaveChangesAsync();

        }

        //ADD LIST OF PRODUCTS TO SHOPPING LIST
        public async Task AddProductsToShoppingListAsync(int shoppingListId, List<ProductToAddDto> products, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            foreach (var productToAdd in products)
            {
                if (productToAdd.Amount <= 0)
                {
                    throw new ArgumentException($"Amount of product (ID: {productToAdd.ProductId}) must be greater than 0.");
                }

                var product = await _context.Products.FindAsync(productToAdd.ProductId);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product (ID: {productToAdd.ProductId}) not found.");
                }

                var productShoppingList = new ProductShoppingList
                {
                    ProductId = productToAdd.ProductId,
                    ShoppingListId = shoppingListId,
                    Amount = productToAdd.Amount
                };

                _context.ProductShoppingLists.Add(productShoppingList);
            }

            await _context.SaveChangesAsync();
        }


        // REMOVE PRODUCT FROM SHOPPING LIST
        public async Task RemoveProductFromShoppingListAsync(int shoppingListId, int productId, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var productShoppingList = await _context.ProductShoppingLists
                .FirstOrDefaultAsync(psl => psl.ShoppingListId == shoppingListId && psl.ProductId == productId);

            if (productShoppingList == null)
            {
                throw new KeyNotFoundException("Product not found on shopping list.");
            }

            _context.ProductShoppingLists.Remove(productShoppingList);
            await _context.SaveChangesAsync();
        }

        // UPDATE PRODUCT ON SHOPPING LIST
        public async Task UpdateProductOnShoppingListAsync(int shoppingListId, int productId, int amount, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (amount <= 0)
            {
                throw new ArgumentException("Amount of Product must be greater than 0.");
            }

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var productShoppingList = await _context.ProductShoppingLists
                .FirstOrDefaultAsync(psl => psl.ShoppingListId == shoppingListId && psl.ProductId == productId);

            if (productShoppingList == null)
            {
                throw new KeyNotFoundException("Product not found on shopping list.");
            }

            productShoppingList.Amount = amount;

            _context.ProductShoppingLists.Update(productShoppingList);
            await _context.SaveChangesAsync();
        }

        // UPDATE AMOUNT OF PRODUCT ON SHOPPING LIST
        public async Task UpdateProductAmountInShoppingListAsync(int shoppingListId, ProductAmountUpdateDto updateDto, string userId)
        {
            var productShoppingList = await _context.ProductShoppingLists
                .FirstOrDefaultAsync(psl => psl.ProductId == updateDto.ProductId && psl.ShoppingListId == shoppingListId);

            if (productShoppingList == null)
            {
                _logger.LogWarning($"Product with ID {updateDto.ProductId} not found on shopping list with ID {shoppingListId}.");
                throw new KeyNotFoundException("Product not found in shopping list.");
            }

            // Prüfen, ob der Benutzer zur Shoppingliste berechtigt ist
            var isUserAuthorized = await _context.UserShoppingLists.AnyAsync(usl => usl.AppUserId == userId && usl.ShoppingListId == shoppingListId);
            if (!isUserAuthorized)
            {
                _logger.LogWarning($"User with ID {userId} is not authorized to update shopping list with ID {shoppingListId}.");
                throw new UnauthorizedAccessException("User is not authorized to update this shopping list.");
            }

            if (updateDto.NewAmount <= 0)
            {
                throw new ArgumentException("Amount must be greater than 0.");
            }

            productShoppingList.Amount = updateDto.NewAmount;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"ProductShoppingList with ID {productShoppingList.Id} updated.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                HandleConcurrencyException(ex, productShoppingList);
                await _context.SaveChangesAsync();
            }
        }


        // HANDLE CONCURRENCY EXCEPTION FOR PRODUCTSHOPPINGLIST
        private void HandleConcurrencyException(DbUpdateConcurrencyException ex, ProductShoppingList conflictedEntity)
        {
            foreach (var entry in ex.Entries)
            {
                if (entry.Entity is ProductShoppingList)
                {
                    var databaseValues = entry.GetDatabaseValues();

                    // Überschreiben der Datenbankwerte mit den Werten des Clients
                    entry.OriginalValues.SetValues(databaseValues);
                    entry.CurrentValues.SetValues(conflictedEntity);

                    _logger.LogWarning($"Concurrency conflict resolved for ProductShoppingList with ID {conflictedEntity.Id}. Client values have been saved.");
                }
            }
        }



        #endregion

        #region CreateAndAddListOfProductsToShoppingList
        /// <summary>
        /// Creates a new shopping list and adds the given products to it. 
        /// In case of an error, the shopping list will be deleted.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="createDto"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task CreateAndAddListOfProductsToShoppingListAsync(string userId, string name, List<ProductItemDto> products)
        {
            try
            {
                var shoppingList = new ShoppingList
                {

                    Name = name,

                };

                try
                {
                    var userShoppingList = new UserShoppingList
                    {
                        AppUserId = userId,
                        ShoppingList = shoppingList
                    };
                    _context.UserShoppingLists.Add(userShoppingList);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while creating shopping list: {ex.Message}");
                    throw;
                }

                try
                {
                    var shoppingListId = shoppingList.Id;

                    foreach (var productToAdd in products)
                    {
                        if (productToAdd.Amount <= 0)
                        {
                            throw new ArgumentException($"Amount of product (ID: {productToAdd.ProductId}) must be greater than 0.");
                        }

                        var product = await _context.Products.FindAsync(productToAdd.ProductId);
                        if (product == null)
                        {
                            throw new KeyNotFoundException($"Product (ID: {productToAdd.ProductId}) not found.");
                        }

                        var productShoppingList = new ProductShoppingList
                        {
                            ProductId = productToAdd.ProductId,
                            ShoppingListId = shoppingListId,
                            Amount = productToAdd.Amount
                        };

                        _context.ProductShoppingLists.Add(productShoppingList);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while adding products to shopping list: {ex.Message}");
                    _context.ShoppingLists.Remove(shoppingList);
                    await _context.SaveChangesAsync();
                    throw;
                }

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while creating shopping list with products: {ex.Message}");
                throw;
            }

        }

        #endregion

        #region Calculate Cheapest Market For ShoppingList

        // CALCULATE TOTAL COST FOR SHOPPING LIST FOR EACH MARKET WITH PRODUCT DETAIL PRICE
        public async Task<List<ShoppingListMarketCostDto>> CalculateShoppingListCostPerMarketWithProductDetailPrice(int shoppingListId, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .Include(sl => sl.ProductShoppingLists).ThenInclude(psl => psl.Product).ThenInclude(p => p.MarketProducts)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var costPerMarket = await CalculateCostPerMarket(shoppingList, new List<string>()); // Ohne gesperrte Märkte

            var shoppingListMarketCosts = costPerMarket.Select(marketCost => new ShoppingListMarketCostDto
            {
                MarketName = marketCost.Key,
                TotalCost = marketCost.Value,
                Items = shoppingList.ProductShoppingLists.Select(psl => new ProductCostDto
                {
                    ProductId = psl.ProductId,
                    ProductName = psl.Product.Name,
                    Quantity = psl.Amount,
                    UnitPrice = psl.Product.MarketProducts.FirstOrDefault(mp => mp.Market.Name == marketCost.Key)?.Price ?? 0,
                    TotalPrice = psl.Amount * (psl.Product.MarketProducts.FirstOrDefault(mp => mp.Market.Name == marketCost.Key)?.Price ?? 0)
                }).ToList()
            }).ToList();

            return shoppingListMarketCosts;
        }


        // CALCULATE TOTAL COST FOR SHOPPING LIST FOR EACH MARKET WITHOUT PRODUCT DETAIL PRICE
        public async Task<Dictionary<string, double>> CalculateTotalCostPerMarketAsync(int shoppingListId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.ProductShoppingLists).ThenInclude(psl => psl.Product).ThenInclude(p => p.MarketProducts)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId);

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            return await CalculateCostPerMarket(shoppingList, new List<string>());
        }

        // CALCULATE TOTAL COST FOR SHOPPING LIST FOR EACH MARKET WITH PRODUCT ID AND AMOUNT
        public async Task<ShoppingListItemsMarketTotalPricesDto> GetShoppingListWithMarketTotalPricesAsync(int shoppingListId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.ProductShoppingLists).ThenInclude(psl => psl.Product).ThenInclude(p => p.MarketProducts)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId);

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var marketTotalPrices = await CalculateCostPerMarket(shoppingList, new List<string>());
            var items = shoppingList.ProductShoppingLists.Select(psl => new ProductAmountDto
            {
                ProductId = psl.ProductId,
                Amount = psl.Amount
            }).ToList();

            return new ShoppingListItemsMarketTotalPricesDto()
            {
                MarketTotalPrices = marketTotalPrices.Select(mtp => new MarketTotalPriceDto
                {
                    MarketName = mtp.Key,
                    TotalPrice = mtp.Value
                }).ToList(),
                Items = items
            };
        }


        // CALCULATE CHEAPEST MARKET FOR SHOPPING LIST
        public async Task<KeyValuePair<string, double>> CalculateCheapestMarketForShoppingListAsync(int shoppingListId,
            string userId)
        {
            var blockedMarkets = await _marketService.GetBlockedMarketsForUserAsync(userId);
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .Include(sl => sl.ProductShoppingLists)
                .ThenInclude(psl => psl.Product)
                .ThenInclude(p => p.MarketProducts)
                .ThenInclude(mp => mp.Market)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var costPerMarket = await CalculateCostPerMarket(shoppingList, blockedMarkets);
            return FindCheapestMarket(costPerMarket);
        }

        #endregion

        #region Get Shopping List Details

        // GET SHOPPING LIST DETAILS
        public async Task<ShoppingListDetailDto> GetShoppingListDetailsAsync(int shoppingListId, string userId)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.UserShoppingLists)
                .Include(sl => sl.ProductShoppingLists)
                .ThenInclude(psl => psl.Product)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId && sl.UserShoppingLists.Any(usl => usl.AppUserId == userId));

            if (shoppingList == null)
            {
                throw new KeyNotFoundException("Shopping list not found.");
            }

            var dto = new ShoppingListDetailDto
            {
                Id = shoppingList.Id,
                Products = new List<ProductDetailDto>(),
                TotalPrice = 0
            };

            foreach (var psl in shoppingList.ProductShoppingLists)
            {
                var product = psl.Product;
                var cheapestMarketProduct = product.MarketProducts
                    .OrderBy(mp => mp.Price)
                    .FirstOrDefault();

                if (cheapestMarketProduct != null)
                {
                    dto.Products.Add(new ProductDetailDto
                    {
                        ProductName = product.Name,
                        ProductCategory = product.ProductCategory?.Name,
                        ProductPrice = cheapestMarketProduct.Price,
                        MarketName = cheapestMarketProduct.Market.Name
                    });

                    dto.TotalPrice += cheapestMarketProduct.Price;
                }
            }

            return dto;
        }

        #endregion

        #region Logic for ShoppingListReadDto calculations
        private async Task<Double> CalculateTotalCost(ShoppingList shoppingList)
        {
            var result = 0.0;

            // Sammle alle Produkt-IDs aus der Einkaufsliste
            var productIds = shoppingList.ProductShoppingLists.Select(psl => psl.ProductId).ToList();

            // Hole alle Marktpreise für diese Produkte in einer Abfrage
            var marketProducts = await _context.MarketProduct
                .Include(mp => mp.Market)
                .Where(mp => productIds.Contains(mp.ProductId))
                .ToListAsync();

            foreach (var productShoppingList in shoppingList.ProductShoppingLists)
            {
                // Finde die zugehörigen Marktpreise für jedes Produkt
                var relevantMarketProducts = marketProducts.Where(mp => mp.ProductId == productShoppingList.ProductId);

                foreach (var marketProduct in relevantMarketProducts)
                {
                    result += marketProduct.Price * productShoppingList.Amount;
                }
            }

            return result;
        }

        private async Task<Dictionary<string, double>> CalculateCostPerMarket(ShoppingList shoppingList,
            List<string> blockedMarkets)
        {
            var result = new Dictionary<string, double>();

            // Sammle alle Produkt-IDs aus der Einkaufsliste
            var productIds = shoppingList.ProductShoppingLists
                .Select(psl => psl.ProductId)
                .ToList();

            // Hole alle Marktpreise für diese Produkte in einer Abfrage
            var marketProducts = await _context.MarketProduct
                .Include(mp => mp.Market)
                .Where(mp => productIds.Contains(mp.ProductId))
                .ToListAsync();

            foreach (var productShoppingList in shoppingList.ProductShoppingLists)
            {
                // Finde die zugehörigen Marktpreise für jedes Produkt
                var relevantMarketProducts = marketProducts
                    .Where(mp => mp.ProductId == productShoppingList.ProductId);

                foreach (var marketProduct in relevantMarketProducts)
                {
                    if (blockedMarkets.Contains(marketProduct.Market.Name))
                    {
                        continue;
                    }

                    if (result.ContainsKey(marketProduct.Market.Name))
                    {
                        result[marketProduct.Market.Name] += marketProduct.Price * productShoppingList.Amount;
                    }
                    else
                    {
                        result.Add(marketProduct.Market.Name, marketProduct.Price * productShoppingList.Amount);
                    }
                }
            }
            return result;
        }




        private KeyValuePair<string, double> FindCheapestMarket(Dictionary<string, double> costPerMarket)
        {
            if (costPerMarket == null || costPerMarket.Count == 0)
            {
                throw new InvalidOperationException("Keine Marktkosten verfügbar für die Berechnung.");
            }
            var cheapestMarket = costPerMarket.Aggregate((l, r) => l.Value < r.Value ? l : r);
            return cheapestMarket;
        }


        #endregion






    }
}
