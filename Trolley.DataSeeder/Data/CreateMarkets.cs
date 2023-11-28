using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trolley.API.Data;
using Trolley.API.Entities;
using Trolley.API.Enums;

namespace Trolley.DataSeeder.Data
{
    public static class CreateMarkets
    {
        public static void Seed(TrolleyDbContext context)
        {
            var markets = new List<Market>
            {
                new Market()
                {
                    Id = GlobalIds.MarketBillaId,
                    Name = "Billa",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketSparId,
                    Name = "Spar",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketHoferId,
                    Name = "Hofer",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketLidlId,
                    Name = "Lidl",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketPennyId,
                    Name = "Penny",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketBillaPlusId,
                    Name = "Billa Plus",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Market()
                {
                    Id = GlobalIds.MarketInterSparId,
                    Name = "Interspar",
                    IsNearest = false,
                    Category = MarketCategory.Supermarket,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },

            };
            foreach (var market in markets)
            {
                // Überprüfe, ob der Markt bereits in der Datenbank existiert
                if (!context.Markets.Any(m => m.Name == market.Name))
                {
                    context.Markets.Add(market);
                }
            }

            context.SaveChanges();
        }
    }
}
