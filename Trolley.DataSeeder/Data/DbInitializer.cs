using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Trolley.API.Data;
using Trolley.API.Entities;
using Trolley.API.Enums;

namespace Trolley.DataSeeder.Data
{
    public static class DbInitializer
    {
        private static Random _random = new Random();
        public static void Initialize(TrolleyDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
            {
                return;
            }


            // Fixed Guid IDs for Markets
            var billaId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var sparId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var lidlId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var hoferId = Guid.Parse("00000000-0000-0000-0000-000000000003");
            var pennyId = Guid.Parse("00000000-0000-0000-0000-000000000004");

            // Fixed Guid IDs for brands
            var cleverId = Guid.Parse("00000000-0000-0000-0000-100000000005");
            var jaNatuerlichId = Guid.Parse("00000000-0000-0000-0000-100000000006");
            var sBudgetId = Guid.Parse("00000000-0000-0000-0000-100000000007");



            // Fixed Guid IDs for Main categories
            var gemueseId = Guid.Parse("00000000-0000-0000-0000-000000000006");
            var obstId = Guid.Parse("00000000-0000-0000-0000-000000000007");
            var getraenkeId = Guid.Parse("00000000-0000-0000-0000-000000000008");
            var fleischId = Guid.Parse("00000000-0000-0000-0000-000000000009");
            var fischId = Guid.Parse("00000000-0000-0000-0000-000000000010");
            // Fixed Guid IDs for Sub categories
            var bananeId = Guid.Parse("00000000-0000-0000-0000-000000000011");
            var apfelId = Guid.Parse("00000000-0000-0000-0000-000000000012");
            var birneId = Guid.Parse("00000000-0000-0000-0000-000000000013");
            var erdbeereId = Guid.Parse("00000000-0000-0000-0000-000000000014");
            var himbeereId = Guid.Parse("00000000-0000-0000-0000-000000000015");

            // Fixed Guid IDs for Icons Main Categories
            var iconGemueseId = Guid.Parse("00000000-0000-0000-0000-000000000016");
            var iconObstId = Guid.Parse("00000000-0000-0000-0000-000000000017");
            var iconGetraenkeId = Guid.Parse("00000000-0000-0000-0000-000000000018");
            var iconFleischId = Guid.Parse("00000000-0000-0000-0000-000000000019");
            var iconFischId = Guid.Parse("00000000-0000-0000-0000-000000000020");

            // Fixed Guid IDs for Icons Sub Categories
            var iconBananeId = Guid.Parse("00000000-0000-0000-0000-000000000021");
            var iconApfelId = Guid.Parse("00000000-0000-0000-0000-000000000022");
            var iconBirneId = Guid.Parse("00000000-0000-0000-0000-000000000023");
            var iconErdbeereId = Guid.Parse("00000000-0000-0000-0000-000000000024");
            var iconHimbeereId = Guid.Parse("00000000-0000-0000-0000-000000000025");



            #region Markets
            // Märkte erstellen
            var markets = new List<Market>
            {
                new Market
                {
                    Id = billaId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Billa",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                },
                new Market
                {
                    Id = sparId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Spar",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                },
                new Market
                {
                    Id = lidlId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Lidl",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                },
                new Market
                {
                    Id = hoferId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Hofer",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                },
                new Market
                {
                    Id = pennyId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Penny",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                },
            };
            foreach (var market in markets)
            {

                context.Markets.Add(market);
            }
            context.SaveChanges();

            #endregion

            #region Brands
            // Brands erstellen
            var brands = new List<Brand>
            {
                new Brand
                {
                    Id = cleverId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Clever",

                },
                new Brand
                {
                    Id = jaNatuerlichId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Ja! Natürlich",
                },
                new Brand
                {
                    Id = sBudgetId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "S-Budget",
                },

            };

            foreach (var brand in brands)
            {
                context.Brands.Add(brand);
            }
            context.SaveChanges();
            #endregion

            #region Category
            // Kategorien erstellen
            var categories = new List<Category>
            {
                new Category
                {
                    Id = gemueseId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Gemüse",
                    ParentCategoryId = null,
                    IconId = iconGemueseId,
                    Icon = new Icon
                    {
                        Id = iconGemueseId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                        Name = "Gemüse",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = obstId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Obst",
                    ParentCategoryId = null,
                    IconId = iconObstId,
                    Icon = new Icon
                    {
                        Id = iconObstId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Obst",
                        Path = null,
                    }

                },
                new Category
                {
                    Id = getraenkeId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Getränke",
                    ParentCategoryId = null,
                    IconId = iconGetraenkeId,
                    Icon = new Icon
                    {
                        Id = iconGetraenkeId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Getränke",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = fleischId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Fleisch",
                    ParentCategoryId = null,
                    IconId = iconFleischId,
                    Icon = new Icon
                    {
                        Id = iconFleischId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Fleisch",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = fischId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Fisch",
                    ParentCategoryId = null,
                    IconId = iconFischId,
                    Icon = new Icon
                    {
                        Id = iconFischId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Fisch",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = erdbeereId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Erdbeere",
                    ParentCategoryId = obstId,
                    IconId = iconErdbeereId,
                    Icon = new Icon
                    {
                        Id = iconErdbeereId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Erdbeere",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = himbeereId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Himbeere",
                    ParentCategoryId = obstId,
                    IconId = iconHimbeereId,
                    Icon = new Icon
                    {
                        Id = iconHimbeereId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Himbeere",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = bananeId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Name = "Banane",
                    ParentCategoryId = obstId,
                    IconId = iconBananeId,
                    Icon = new Icon
                    {
                        Id = iconBananeId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                        Name = "Banane",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = apfelId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Apfel",
                    ParentCategoryId = obstId,
                    IconId = iconApfelId,
                    Icon = new Icon
                    {
                        Id = iconApfelId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                        Name = "Apfel",
                        Path = null,
                    }
                },
                new Category
                {
                    Id = birneId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Name = "Birne",
                    ParentCategoryId = obstId,
                    IconId = iconBirneId,
                    Icon = new Icon
                    {
                        Id = iconBirneId,
                        CreatedBy = "Codegenerator",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ModifiedBy = "Codegenerator",
                        Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                        Name = "Birne",
                        Path = null,
                    }
                },
            };
            foreach (var category in categories)
            {

                context.Categories.Add(category);
            }
            context.SaveChanges();

            #endregion

            #region Products

            // Produkte erstellen

            #endregion

            AddProductWithRandomPrices(
                context,
                "Bio Bananen",
                true,
                bananeId,
                new[] { billaId, hoferId, sparId, lidlId, pennyId },
                () => GenerateRandomPrice(1.7, 2.7));

            AddProductWithRandomPrices(
                context,
                "Normale Bananen",
                false,
                bananeId,
                new[] { billaId, hoferId, sparId, lidlId, pennyId },
                () => GenerateRandomPrice(1.2, 2.1));

            AddProductWithRandomPrices(
                context,
                "Bio Äpfel",
                true,
                apfelId,
                new[] { billaId, hoferId, sparId, lidlId, pennyId },
                () => GenerateRandomPrice(2.0, 3.0));

            AddProductWithRandomPrices(
                context,
                "Normale Äpfel",
                false,
                apfelId,
                new[] { billaId, hoferId, sparId, lidlId, pennyId },
                () => GenerateRandomPrice(1.5, 2.5));



        }

        private static void AddProductWithRandomPrices(
            TrolleyDbContext context,
            string productName,
            bool isOrganic,
            //Guid brandId,
            Guid categoryId,
            Guid[] marketIds,
            Func<double> priceGenerator)
        {
            var productId = Guid.NewGuid();

            var product = new Product
            {
                Id = productId,
                CreatedBy = "Codegenerator",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = "Codegenerator",
                Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                Name = productName,
                Description = productName + "Beschreibung",
                IsOrganic = isOrganic,
                IsAvailable = true,
                //BrandId = brandId,
                ProductCategoryId = categoryId,
            };

            context.Products.Add(product);

            foreach (var marketId in marketIds)
            {
                var priceId = Guid.NewGuid();
                var priceAmount = priceGenerator();
                var price = new Price
                {
                    Id = priceId,
                    CreatedBy = "Codegenerator",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ModifiedBy = "Codegenerator",
                    PriceTimestamp = DateTime.Now,
                    Timestamp = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                    Amount = priceAmount,
                    MarketProductPrices = new List<MarketProductPrice>(),
                };

                context.Prices.Add(price);

                var marketProductPrice = new MarketProductPrice
                {
                    MarketId = marketId,
                    ProductId = productId,
                    PriceId = priceId,
                };

                context.MarketProductPrices.Add(marketProductPrice);
            }
            context.SaveChanges();
        }

        private static double GenerateRandomPrice(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }
    }
}
