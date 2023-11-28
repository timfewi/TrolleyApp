using Trolley.API.Data;
using Trolley.DataSeeder.Data;

public static class DbInitializer
{
    public static void Initialize(TrolleyDbContext context)
    {
        // Andere Seed-Operationen...

        // Märkte seeden
        CreateMarkets.Seed(context);
        CreateIcons.Seed(context);
        CreateCategories.Seed(context);


        // Weitere Seed-Operationen...
    }
}