using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;

namespace Trolley.API.Data
{
    public class TrolleyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
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
                new Market { Id = 3, Name = "Hofer" }
                );

            // Seed Data for Brands
            modelBuilder.Entity<Brand>().HasData(
                // Billa Brands
                new Brand { Id = 1, Name = "Ja! Natürlich" },
                new Brand { Id = 2, Name = "Billa" },
                new Brand { Id = 3, Name = "Billa Corso" },
                // Spar Brands
                new Brand { Id = 4, Name = "Natur Pur" },
                new Brand { Id = 5, Name = "S-Budget" },
                new Brand { Id = 6, Name = "Spar Vital" },
                // Hofer Brands
                new Brand { Id = 7, Name = "Zurück zum Ursprung" },
                new Brand { Id = 8, Name = "Hofer Bio" },
                new Brand { Id = 9, Name = "Hofer Selection" }

                );

            #region IconNames
            //Forelle - fish
            //Lachs - fish
            //Garnelen - shrimp
            //Shrimps - shrimp
            //Marmelade - jar
            //Nutella - jar
            //Honig - jar
            //Sugo - jar
            //Pesto - jar
            //Eis - ice - cream
            //Ei - egg
            //Hühnerkeule - drumstick - bite
            //Entenkeule - drumstick - bite
            //Eiswürfel - cubes - stacked
            //Rotwein - wine - bottle
            //Weißwein - wine - bottle
            //Waffeln - stroopwafel
            //Tiefkühlpizza - pizza - slice
            //Pfefferoni - pepper - hot
            //Chili - pepper - hot
            //Dinkelkekse - cookie
            //Camembert - cheese
            //Gouda - cheese
            //Karotte - carrot
            //Burger - burger
            //Schwarzbrot - bread - slice
            //Weißbrot - bread - slice
            //Toast - bread - slice
            //Reis - bowl - rice
            //Mineralwasser(still) - bottle - water
            //Mineralwasser(mild) - bottle - water
            //Mineralwasser(prickelnd) - bottle - water
            //Speck - bacon
            //Apfel - apple - whole
            #endregion

            #region Products
            modelBuilder.Entity<Product>().HasData(
                //Apfel
                new Product { Id = 1, Name = "Apfel", ProductCategoryId = 1, IconName = "apple-whole", IsOrganic = false, IsDiscountProduct = false },
                new Product { Id = 2, Name = "Apfel", ProductCategoryId = 1, IconName = "apple-whole", IsOrganic = true, IsDiscountProduct = false },
                new Product { Id = 3, Name = "Apfel", ProductCategoryId = 1, IconName = "apple-whole", IsOrganic = false, IsDiscountProduct = true },
                // Forelle
                new Product { Id = 4, Name = "Forelle", ProductCategoryId = 5, IconName = "fish", IsOrganic = false, IsDiscountProduct = false },
                new Product { Id = 5, Name = "Forelle", ProductCategoryId = 5, IconName = "fish", IsOrganic = true, IsDiscountProduct = false },
                new Product { Id = 6, Name = "Forelle", ProductCategoryId = 5, IconName = "fish", IsOrganic = false, IsDiscountProduct = true, },
                // Lachs
                new Product { Id = 7, Name = "Lachs", ProductCategoryId = 5, IconName = "fish", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 8, Name = "Lachs", ProductCategoryId = 5, IconName = "fish", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 9, Name = "Lachs", ProductCategoryId = 5, IconName = "fish", IsOrganic = false, IsDiscountProduct = true, },
                // Garnelen
                new Product { Id = 10, Name = "Garnelen", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 11, Name = "Garnelen", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 12, Name = "Garnelen", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = false, IsDiscountProduct = true, },
                // Shrimps
                new Product { Id = 13, Name = "Shrimps", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 14, Name = "Shrimps", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 15, Name = "Shrimps", ProductCategoryId = 5, IconName = "shrimp", IsOrganic = false, IsDiscountProduct = true, },
                // Marmelade
                new Product { Id = 16, Name = "Marmelade", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 17, Name = "Marmelade", ProductCategoryId = 8, IconName = "jar", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 18, Name = "Marmelade", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = true, },
                // Nutella
                new Product { Id = 19, Name = "Nutella", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 20, Name = "Nutella", ProductCategoryId = 8, IconName = "jar", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 21, Name = "Nutella", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = true, },
                // Honig
                new Product { Id = 22, Name = "Honig", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 23, Name = "Honig", ProductCategoryId = 8, IconName = "jar", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 24, Name = "Honig", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = true, },
                // Sugo
                new Product { Id = 25, Name = "Sugo", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 26, Name = "Sugo", ProductCategoryId = 8, IconName = "jar", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 27, Name = "Sugo", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = true, },
                // Pesto
                new Product { Id = 28, Name = "Pesto", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 29, Name = "Pesto", ProductCategoryId = 8, IconName = "jar", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 30, Name = "Pesto", ProductCategoryId = 8, IconName = "jar", IsOrganic = false, IsDiscountProduct = true, },
                // Eis
                new Product { Id = 31, Name = "Eis", ProductCategoryId = 10, IconName = "ice-cream", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 32, Name = "Eis", ProductCategoryId = 10, IconName = "ice-cream", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 33, Name = "Eis", ProductCategoryId = 10, IconName = "ice-cream", IsOrganic = false, IsDiscountProduct = true, },
                // Ei
                new Product { Id = 34, Name = "Ei", ProductCategoryId = 1, IconName = "egg", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 35, Name = "Ei", ProductCategoryId = 1, IconName = "egg", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 36, Name = "Ei", ProductCategoryId = 1, IconName = "egg", IsOrganic = false, IsDiscountProduct = true, },
                // Hühnerkeule
                new Product { Id = 37, Name = "Hühnerkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 38, Name = "Hühnerkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 39, Name = "Hühnerkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = false, IsDiscountProduct = true, },
                // Entenkeule
                new Product { Id = 40, Name = "Entenkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 41, Name = "Entenkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 42, Name = "Entenkeule", ProductCategoryId = 4, IconName = "drumstick-bite", IsOrganic = false, IsDiscountProduct = true, },
                // Eiswürfel
                new Product { Id = 43, Name = "Eiswürfel", ProductCategoryId = 9, IconName = "cubes-stacked", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 44, Name = "Eiswürfel", ProductCategoryId = 9, IconName = "cubes-stacked", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 45, Name = "Eiswürfel", ProductCategoryId = 9, IconName = "cubes-stacked", IsOrganic = false, IsDiscountProduct = true, },
                // Rotwein
                new Product { Id = 46, Name = "Rotwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 47, Name = "Rotwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 48, Name = "Rotwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = false, IsDiscountProduct = true, },
                // Weißwein
                new Product { Id = 49, Name = "Weißwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 50, Name = "Weißwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 51, Name = "Weißwein", ProductCategoryId = 9, IconName = "wine-bottle", IsOrganic = false, IsDiscountProduct = true, },
                // Waffeln
                new Product { Id = 52, Name = "Waffeln", ProductCategoryId = 10, IconName = "stroopwafel", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 53, Name = "Waffeln", ProductCategoryId = 10, IconName = "stroopwafel", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 54, Name = "Waffeln", ProductCategoryId = 10, IconName = "stroopwafel", IsOrganic = false, IsDiscountProduct = true, },
                // Tiefkühlpizza
                new Product { Id = 55, Name = "Tiefkühlpizza", ProductCategoryId = 10, IconName = "pizza-slice", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 56, Name = "Tiefkühlpizza", ProductCategoryId = 10, IconName = "pizza-slice", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 57, Name = "Tiefkühlpizza", ProductCategoryId = 10, IconName = "pizza-slice", IsOrganic = false, IsDiscountProduct = true, },
                // Pfefferoni
                new Product { Id = 58, Name = "Pfefferoni", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 59, Name = "Pfefferoni", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 60, Name = "Pfefferoni", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = false, IsDiscountProduct = true, },
                // Chili
                new Product { Id = 61, Name = "Chili", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 62, Name = "Chili", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 63, Name = "Chili", ProductCategoryId = 8, IconName = "pepper-hot", IsOrganic = false, IsDiscountProduct = true, },
                // Dinkelkekse
                new Product { Id = 64, Name = "Dinkelkekse", ProductCategoryId = 10, IconName = "cookie", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 65, Name = "Dinkelkekse", ProductCategoryId = 10, IconName = "cookie", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 66, Name = "Dinkelkekse", ProductCategoryId = 10, IconName = "cookie", IsOrganic = false, IsDiscountProduct = true, },
                // Camembert
                new Product { Id = 67, Name = "Camembert", ProductCategoryId = 6, IconName = "cheese", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 68, Name = "Camembert", ProductCategoryId = 6, IconName = "cheese", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 69, Name = "Camembert", ProductCategoryId = 6, IconName = "cheese", IsOrganic = false, IsDiscountProduct = true, },
                // Gouda
                new Product { Id = 70, Name = "Gouda", ProductCategoryId = 6, IconName = "cheese", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 71, Name = "Gouda", ProductCategoryId = 6, IconName = "cheese", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 72, Name = "Gouda", ProductCategoryId = 6, IconName = "cheese", IsOrganic = false, IsDiscountProduct = true, },
                // Karotte
                new Product { Id = 73, Name = "Karotte", ProductCategoryId = 2, IconName = "carrot", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 74, Name = "Karotte", ProductCategoryId = 2, IconName = "carrot", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 75, Name = "Karotte", ProductCategoryId = 2, IconName = "carrot", IsOrganic = false, IsDiscountProduct = true, },
                // Burger
                new Product { Id = 76, Name = "Burger", ProductCategoryId = 4, IconName = "burger", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 77, Name = "Burger", ProductCategoryId = 4, IconName = "burger", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 78, Name = "Burger", ProductCategoryId = 4, IconName = "burger", IsOrganic = false, IsDiscountProduct = true, },
                // Schwarzbrot
                new Product { Id = 79, Name = "Schwarzbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 80, Name = "Schwarzbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 81, Name = "Schwarzbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = true, },
                // Weißbrot
                new Product { Id = 82, Name = "Weißbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 83, Name = "Weißbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 84, Name = "Weißbrot", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = true, },
                // Toast
                new Product { Id = 85, Name = "Toast", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 86, Name = "Toast", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 87, Name = "Toast", ProductCategoryId = 3, IconName = "bread-slice", IsOrganic = false, IsDiscountProduct = true, },
                // Reis
                new Product { Id = 88, Name = "Reis", ProductCategoryId = 3, IconName = "bowl-rice", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 89, Name = "Reis", ProductCategoryId = 3, IconName = "bowl-rice", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 90, Name = "Reis", ProductCategoryId = 3, IconName = "bowl-rice", IsOrganic = false, IsDiscountProduct = true, },
                // Mineralwasser(still)
                new Product { Id = 91, Name = "Mineralwasser(still)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 92, Name = "Mineralwasser(still)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 93, Name = "Mineralwasser(still)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = true, },
                // Mineralwasser(mild)
                new Product { Id = 94, Name = "Mineralwasser(mild)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 95, Name = "Mineralwasser(mild)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 96, Name = "Mineralwasser(mild)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = true, },
                // Mineralwasser(prickelnd)
                new Product { Id = 97, Name = "Mineralwasser(prickelnd)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 98, Name = "Mineralwasser(prickelnd)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 99, Name = "Mineralwasser(prickelnd)", ProductCategoryId = 9, IconName = "water-bottle", IsOrganic = false, IsDiscountProduct = true, },
                // Speck
                new Product { Id = 100, Name = "Speck", ProductCategoryId = 4, IconName = "bacon", IsOrganic = false, IsDiscountProduct = false, },
                new Product { Id = 101, Name = "Speck", ProductCategoryId = 4, IconName = "bacon", IsOrganic = true, IsDiscountProduct = false, },
                new Product { Id = 102, Name = "Speck", ProductCategoryId = 4, IconName = "bacon", IsOrganic = false, IsDiscountProduct = true, }

            );
            #endregion


            #region BrandProducts
            // Brand IDs = 1-9
            // 1-3 Billa =
            // Ja! Natürlich = 1,
            // Billa = 2,
            // Billa Corso = 3

            // 4-6 Spar =
            // Natur Pur = 4,
            // S-Budget = 5,
            // Spar Vital = 6

            // 7-9 Hofer =
            // Zurück zum Ursprung = 7,
            // Hofer Bio = 8,
            // Hofer Selection = 9

            //modelBuilder.Entity<BrandProduct>().HasData(
            //    new BrandProduct { BrandId = 1, ProductId = 1, Price =  },
            //    );

            #endregion

        }


        public override int SaveChanges()
        {

            ApplyDateAndUser();

            var result = base.SaveChanges();

            ChangeTracker.Clear();


            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            ApplyDateAndUser();

            var result = await base.SaveChangesAsync(cancellationToken);

            ChangeTracker.Clear();

            return result;
        }

        private void ApplyDateAndUser()
        {

            var currentUser = "SYSTEM";

            var changedEntries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified))
                .ToList();

            var deletedEntries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Deleted))
                .ToList();

            var now = DateTime.Now;

            foreach (var entityEntry in changedEntries)
            {
                if (currentUser == null)
                    throw new InvalidOperationException("CurrentUser not set.");

                var baseEntity = ((BaseEntity)entityEntry.Entity);

                baseEntity.DateModified = now;
                baseEntity.ModifiedBy = currentUser;

                if (entityEntry.State == EntityState.Added)
                {
                    baseEntity.DateCreated = now;
                    baseEntity.CreatedBy = currentUser;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    var originalDateCreated = entityEntry.OriginalValues.GetValue<DateTime>(nameof(BaseEntity.DateCreated));
                    var originalCreatedById = entityEntry.OriginalValues.GetValue<string>(nameof(BaseEntity.CreatedBy));

                    baseEntity.DateCreated = originalDateCreated;
                    baseEntity.CreatedBy = originalCreatedById;
                }
            }
        }



    }
}
