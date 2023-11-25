using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;

namespace Trolley.Domain.Data
{
    public class TrolleyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> ProductCategory { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandProduct> BrandProducts { get; set; }
        public DbSet<MarketProductPrice> MarketProductPrices { get; set; }
        public DbSet<ProductShoppingList> ProductShoppingLists { get; set; }
        public DbSet<ShoppingListUser> ShoppingListUsers { get; set; }
        public DbSet<User> User { get; set; }


        public TrolleyDbContext(DbContextOptions<TrolleyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MarketProductPrice
            modelBuilder.Entity<MarketProductPrice>()
                .HasKey(mpp => new { mpp.MarketId, mpp.ProductId, mpp.PriceId });
            modelBuilder.Entity<MarketProductPrice>()
                .HasOne(mpp => mpp.Market)
                .WithMany(m => m.MarketProductPrices)
                .HasForeignKey(mpp => mpp.MarketId);
            modelBuilder.Entity<MarketProductPrice>()
                .HasOne(mpp => mpp.Product)
                .WithMany(p => p.MarketProductPrices)
                .HasForeignKey(mpp => mpp.ProductId);
            modelBuilder.Entity<MarketProductPrice>()
                .HasOne(mpp => mpp.Price)
                .WithMany(p => p.MarketProductPrices)
                .HasForeignKey(mpp => mpp.PriceId);



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

        }
    }
}
