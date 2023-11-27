using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trolley.API.Data;
using Trolley.API.Entities;
using Trolley.DataSeeder.Data;

namespace Trolley.DataSeeder;

class Program
{
    public static void Main(string[] args)
    {
        //var connectionString =
        //    "Data Source=localhost;Initial Catalog=TrolleyDB;Trusted_Connection=True;TrustServerCertificate=true;";
        //var optionsBuilder = new DbContextOptionsBuilder<TrolleyDbContext>();
        //optionsBuilder.UseSqlServer(connectionString);

        //using (var context = new TrolleyDbContext(optionsBuilder.Options))
        //{
        //    // Aufrufen der Seed-Methode
        //    DbInitializer.Initialize(context);
        //}

        //Console.WriteLine("Datenbank wurde erfolgreich mit Seed-Daten gefüllt.");
    }

}