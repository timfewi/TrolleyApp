using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;

namespace Trolley.API.Data
{
    public class TrolleyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandProduct> BrandProducts { get; set; }
        public DbSet<MarketProduct> MarketProduct { get; set; }
        public DbSet<ProductShoppingList> ProductShoppingLists { get; set; }
        public DbSet<ShoppingListUser> ShoppingListUsers { get; set; }
        public DbSet<User> User { get; set; }


        public TrolleyDbContext(DbContextOptions<TrolleyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MarketProduct
            modelBuilder.Entity<MarketProduct>()
                .HasKey(mpp => new { mpp.MarketId, mpp.ProductId });
            modelBuilder.Entity<MarketProduct>()
                .HasOne(mpp => mpp.Market)
                .WithMany(m => m.MarketProduct)
                .HasForeignKey(mpp => mpp.MarketId);
            modelBuilder.Entity<MarketProduct>()
                .HasOne(mpp => mpp.Product)
                .WithMany(p => p.MarketProducts)
                .HasForeignKey(mpp => mpp.ProductId);



            // ProductShoppingList
            modelBuilder.Entity<ProductShoppingList>()
                .HasKey(psl => new { psl.ProductId, psl.ShoppingListId });
            modelBuilder.Entity<ProductShoppingList>()
                .HasOne(psl => psl.Product)
                .WithMany(p => p.ProductShoppingLists)
                .HasForeignKey(psl => psl.ProductId);
            modelBuilder.Entity<ProductShoppingList>()
                .HasOne(psl => psl.ShoppingList)
                .WithMany(sl => sl.ProductShoppingLists)
                .HasForeignKey(psl => psl.ShoppingListId);



            // ShoppingListUser
            modelBuilder.Entity<ShoppingListUser>()
                .HasKey(slu => new { slu.ShoppingListId, slu.UserId });
            modelBuilder.Entity<ShoppingListUser>()
                .HasOne(slu => slu.ShoppingList)
                .WithMany(sl => sl.ShoppingListUsers)
                .HasForeignKey(slu => slu.ShoppingListId);
            modelBuilder.Entity<ShoppingListUser>()
                .HasOne(slu => slu.User)
                .WithMany(u => u.ShoppingListUsers)
                .HasForeignKey(slu => slu.UserId);


            //BrandProduct
            modelBuilder.Entity<BrandProduct>()
                .HasKey(bp => new { bp.BrandId, bp.ProductId });
            modelBuilder.Entity<BrandProduct>()
                .HasOne(bp => bp.Brand)
                .WithMany(b => b.BrandProducts)
                .HasForeignKey(bp => bp.BrandId);
            modelBuilder.Entity<BrandProduct>()
                .HasOne(bp => bp.Product)
                .WithMany(p => p.BrandProducts)
                .HasForeignKey(bp => bp.ProductId);


            // Seed data for ProductCategory
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Obst" },
                new ProductCategory { Id = 2, Name = "Gemüse" },
                new ProductCategory { Id = 3, Name = "Getreideprodukte" },
                new ProductCategory { Id = 4, Name = "Fleisch & Geflügel" },
                new ProductCategory { Id = 5, Name = "Fisch & Meeresfrüchte" },
                new ProductCategory { Id = 6, Name = "Milchprodukte" },
                new ProductCategory { Id = 7, Name = "Samen & Hülsenfrüchte" },
                new ProductCategory { Id = 8, Name = "Zutaten & Gewürze" },
                new ProductCategory { Id = 9, Name = "Getränke" },
                new ProductCategory { Id = 10, Name = "Süssigkeiten & Snacks" },
                new ProductCategory { Id = 11, Name = "Kaffee & Tee" },
                new ProductCategory { Id = 12, Name = "Pflege & Gesundheit" },
                new ProductCategory { Id = 13, Name = "Haushalt" }
            );

            // Seed data for Markets
            modelBuilder.Entity<Market>().HasData(
                new Market { Id = 1, Name = "Billa" },
                new Market { Id = 2, Name = "Spar" },
                new Market { Id = 3, Name = "Hofer" },
                new Market { Id = 4, Name = "Lidl" },
                new Market { Id = 5, Name = "Penny" }
                );

            // Seed Data for Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Ja! Natürlich" },
                new Brand { Id = 2, Name = "S-Budget" },
                new Brand { Id = 3, Name = "Spar" },
                new Brand { Id = 4, Name = "Billa" },
                new Brand { Id = 5, Name = "Hofer" },
                new Brand { Id = 6, Name = "Lidl" },
                new Brand { Id = 7, Name = "Penny" },
                new Brand { Id = 8, Name = "Milka" },
                new Brand { Id = 9, Name = "Manner" },
                new Brand { Id = 10, Name = "Ferrero" },
                new Brand { Id = 11, Name = "Red Bull" },
                new Brand { Id = 12, Name = "Coca Cola" },
                new Brand { Id = 13, Name = "Pepsi" },
                new Brand { Id = 14, Name = "Nestle" },
                new Brand { Id = 15, Name = "Maggi" },
                new Brand { Id = 16, Name = "Knorr" },
                new Brand { Id = 17, Name = "Ariel" },
                new Brand { Id = 18, Name = "Persil" },
                new Brand { Id = 19, Name = "Lenor" },
                new Brand { Id = 20, Name = "Head & Shoulders" },
                new Brand { Id = 21, Name = "Nivea" },
                new Brand { Id = 22, Name = "Dove" },
                new Brand { Id = 23, Name = "Balea" },
                new Brand { Id = 24, Name = "Palmolive" },
                new Brand { Id = 25, Name = "Colgate" },
                new Brand { Id = 26, Name = "Signal" },
                new Brand { Id = 27, Name = "Oral-B" },
                new Brand { Id = 28, Name = "Blend-a-med" },
                new Brand { Id = 29, Name = "Listerine" }
                );

        }
    }
}
