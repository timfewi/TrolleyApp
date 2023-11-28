using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trolley.API.Data;
using Trolley.API.Entities;

namespace Trolley.DataSeeder.Data
{
    public static class CreateIcons
    {
        public static void Seed(TrolleyDbContext context)
        {
            #region Icons

            var icons = new List<Icon>
            {
                //Obst
                new Icon()
                {
                    Id = GlobalIds.IconObstId,
                    Name = "Obst",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Gemüse
                new Icon()
                {
                    Id = GlobalIds.IconGemueseId,
                    Name = "Gemüse",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Fleisch
                new Icon()
                {
                    Id = GlobalIds.IconFleischId,
                    Name = "Fleisch",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Fisch
                new Icon()
                {
                    Id = GlobalIds.IconFischId,
                    Name = "Fisch",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Milchprodukte
                new Icon()
                {
                    Id = GlobalIds.IconMilchProdukteId,
                    Name = "Milchprodukte",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Getränke
                new Icon()
                {
                    Id = GlobalIds.IconGetraenkeId,
                    Name = "Getränke",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Süßigkeiten
                new Icon()
                {
                    Id = GlobalIds.IconSuesswarenId,
                    Name = "Süßigkeiten",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Tiefkühl
                new Icon()
                {
                    Id = GlobalIds.IconTiefkuehlId,
                    Name = "Tiefkühl",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                // Sonstiges
                new Icon()
                {
                    Id = GlobalIds.IconSonstigesId,
                    Name = "Sonstiges",
                    Path = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
            };

            foreach (var icon in icons)
            {
                var existingIcon = context.Icons.Find(icon.Id);
                if (existingIcon == null)
                {
                    context.Icons.Add(icon);
                }
                else
                {
                    // Optional: Aktualisiere Eigenschaften des vorhandenen Icons
                    // existingIcon.Name = icon.Name;
                    // existingIcon.Path = icon.Path;
                    // ...
                }
            }
            context.SaveChanges();
            #endregion
        }
    }
}
