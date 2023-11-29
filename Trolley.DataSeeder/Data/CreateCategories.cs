using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trolley.API.Data;
using Trolley.API.Entities;

namespace Trolley.DataSeeder.Data
{
    public static class CreateCategories
    {
        public static void Seed(TrolleyDbContext context)
        {
            #region MainCategories
            var mainCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.MainCatObstId,
                    Name = "Obst",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatGemueseId,
                    Name = "Gemüse",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatBackwarenId,
                    Name = "Backwaren",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatFischId,
                    Name = "Fisch",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatFleischId,
                    Name = "Fleisch",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatMilchProdukteId,
                    Name = "Milchprodukte",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatGetraenkeId,
                    Name = "Getränke",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatSuesswarenId,
                    Name = "Süßwaren",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.MainCatTiefkuehlId,
                    Name = "Tiefkühl",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                new Category()
                {
                    Id = GlobalIds.MainCatSonstigesId,
                    Name = "Sonstiges",
                    ParentCategoryId = null,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
            };

            foreach (var mainCategory in mainCategories)
            {
                var existingMainCategory = context.Categories.Find(mainCategory.Id);
                if (existingMainCategory == null)
                {
                    context.Categories.Add(mainCategory);
                }
            }
            context.SaveChanges();
            #endregion

            #region ObstSubCategories

            var obstSubCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.SubCatAepfelId,
                    Name = "Äpfel",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatBananenId,
                    Name = "Bananen",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatBirnenId,
                    Name = "Birnen",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatErdbeerenId,
                    Name = "Erdbeeren",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatHimbeerenId,
                    Name = "Himbeeren",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatKirschenId,
                    Name = "Kirschen",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatPfirsicheId,
                    Name = "Pfirsiche",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatTraubenId,
                    Name = "Trauben",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatZitronenId,
                   Name = "Zitronen",
                   ParentCategoryId = GlobalIds.MainCatObstId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatZwetschkenId,
                   Name = "Zwetschken",
                   ParentCategoryId = GlobalIds.MainCatObstId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatMarillenId,
                   Name = "Marillen",
                   ParentCategoryId = GlobalIds.MainCatObstId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatMelonenId,
                   Name = "Melonen",
                   ParentCategoryId = GlobalIds.MainCatObstId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatKiwisId,
                    Name = "Kiwis",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatHeidelbeerenId,
                    Name = "Heidelbeeren",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatOrangenId,
                    Name = "Orangen",
                    ParentCategoryId = GlobalIds.MainCatObstId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
            };

            foreach (var obst in obstSubCategories)
            {
                var existingObst = context.Categories.Find(obst.Id);
                if (existingObst == null)
                {
                    context.Categories.Add(obst);
                }
            }
            context.SaveChanges();
            #endregion

            #region GemueseSubCategories

            var gemueseSubCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.SubCatKartoffelnId,
                    Name = "Kartoffeln",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatKarottenId,
                   Name = "Karotten",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatZwiebelnId,
                   Name = "Zwiebeln",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatTomatenId,
                   Name = "Tomaten",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatGurkenId,
                   Name = "Gurken",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatPaprikaId,
                   Name = "Paprika",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatKohlrabiId,
                   Name = "Kohlrabi",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatSalatId,
                   Name = "Salat",
                   ParentCategoryId = GlobalIds.MainCatGemueseId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatKuerbisId,
                    Name = "Kürbis",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatSellerieId,
                    Name = "Sellerie",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatSpinatId,
                    Name = "Spinat",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatBrokkoliId,
                    Name = "Brokkoli",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatZucchiniId,
                    Name = "Zucchini",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatBlumenkohlId,
                    Name = "Blumenkohl",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    // Champignons
                    Id = GlobalIds.SubCatChampignonsId,
                    Name = "Champignons",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Eierschwammerl
                new Category()
                {
                    Id = GlobalIds.SubCatEierschwammerlId,
                    Name = "Eierschwammerl",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Erbsen
                new Category()
                {
                    Id = GlobalIds.SubCatErbsenId,
                    Name = "Erbsen",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Fisolen
                new Category()
                {
                    Id = GlobalIds.SubCatFisolenId,
                    Name = "Fisolen",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Lauch
                new Category()
                {
                    Id = GlobalIds.SubCatLauchId,
                    Name = "Lauch",
                    ParentCategoryId = GlobalIds.MainCatGemueseId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
            };

            foreach (var gemuese in gemueseSubCategories)
            {
                var existingGemuese = context.Categories.Find(gemuese.Id);
                if (existingGemuese == null)
                {
                    context.Categories.Add(gemuese);
                }
            }
            context.SaveChanges();

            #endregion

            #region FleischSubCategories

            var fleischSubCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.SubCatRindfleischId,
                    Name = "Rindfleisch",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatSchweinefleischId,
                   Name = "Schweinefleisch",
                   ParentCategoryId = GlobalIds.MainCatFleischId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatHuehnerfleischId,
                   Name = "Hühnerfleisch",
                   ParentCategoryId = GlobalIds.MainCatFleischId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatPutenfleischId,
                   Name = "Putenfleisch",
                   ParentCategoryId = GlobalIds.MainCatFleischId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatLammfleischId,
                   Name = "Lammfleisch",
                   ParentCategoryId = GlobalIds.MainCatFleischId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatWildfleischId,
                    Name = "Wildfleisch",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    // Kalbfleisch
                    Id = GlobalIds.SubCatKalbfleischId,
                    Name = "Kalbfleisch",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Hackfleisch
                new Category()
                {
                    Id = GlobalIds.SubCatFaschiertesId,
                    Name = "Faschiertes",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Wurst
                new Category()
                {
                    Id = GlobalIds.SubCatWurstId,
                    Name = "Wurst",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Speck
                new Category()
                {
                    Id = GlobalIds.SubCatSpeckId,
                    Name = "Speck",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Schinken
                new Category()
                {
                    Id = GlobalIds.SubCatSchinkenId,
                    Name = "Schinken",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Salami
                new Category()
                {
                    Id = GlobalIds.SubCatSalamiId,
                    Name = "Salami",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Leberkäse
                new Category()
                {
                    Id = GlobalIds.SubCatLeberkaeseId,
                    Name = "Leberkäse",
                    ParentCategoryId = GlobalIds.MainCatFleischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
            };

            foreach (var fleisch in fleischSubCategories)
            {
                var existingFleisch = context.Categories.Find(fleisch.Id);
                if (existingFleisch == null)
                {
                    context.Categories.Add(fleisch);
                }
            }
            context.SaveChanges();
            #endregion

            #region FischSubCategories

            var fischSubCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.SubCatLachsId,
                    Name = "Lachs",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatForelleId,
                    Name = "Forelle",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatThunfischId,
                    Name = "Thunfisch",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatScholleId,
                    Name = "Scholle",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    // Garnelen
                    Id = GlobalIds.SubCatGarnelenId,
                    Name = "Garnelen",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Schwertfisch
                new Category()
                {
                    Id = GlobalIds.SubCatSchwertfischId,
                    Name = "Schwertfisch",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Kabeljau
                new Category()
                {
                    Id = GlobalIds.SubCatKabeljauId,
                    Name = "Kabeljau",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Tintenfisch
                new Category()
                {
                    Id = GlobalIds.SubCatTintenfischId,
                    Name = "Tintenfisch",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Seelachs
                new Category()
                {
                    Id = GlobalIds.SubCatSeelachsId,
                    Name = "Seelachs",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Muscheln
                new Category()
                {
                    Id = GlobalIds.SubCatMuschelnId,
                    Name = "Muscheln",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Heilbutt
                new Category()
                {
                    Id = GlobalIds.SubCatHeilbuttId,
                    Name = "Heilbutt",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Hummer
                new Category()
                {
                    Id = GlobalIds.SubCatHummerId,
                    Name = "Hummer",
                    ParentCategoryId = GlobalIds.MainCatFischId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                }
            };

            foreach (var fisch in fischSubCategories)
            {
                var existingFisch = context.Categories.Find(fisch.Id);
                if (existingFisch == null)
                {
                    context.Categories.Add(fisch);
                }
            }
            context.SaveChanges();
            #endregion

            #region MilchProdukteSubCategories

            var milchProdukteSubCategories = new List<Category>
            {
                new Category()
                {
                    Id = GlobalIds.SubCatMilchId,
                    Name = "Milch",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatJoghurtId,
                   Name = "Joghurt",
                   ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatKaeseId,
                   Name = "Käse",
                   ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatButterId,
                   Name = "Butter",
                   ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                   Id = GlobalIds.SubCatTopfenId,
                   Name = "Topfen",
                   ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                   IconId = null,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now,
                   CreatedBy = "Seeder"
                },
                new Category()
                {
                    Id = GlobalIds.SubCatSahneId,
                    Name = "Sahne",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder"
                },
                new Category()
                {
                    // Schlagobers
                    Id = GlobalIds.SubCatSchlagobersId,
                    Name = "Schlagobers",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Eier
                new Category()
                {
                    Id = GlobalIds.SubCatEierId,
                    Name = "Eier",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Quark
                new Category()
                {
                    Id = GlobalIds.SubCatQuarkId,
                    Name = "Quark",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Mascarpone
                new Category()
                {
                    Id = GlobalIds.SubCatMascarponeId,
                    Name = "Mascarpone",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Mozzarella
                new Category()
                {
                    Id = GlobalIds.SubCatMozzarellaId,
                    Name = "Mozzarella",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Ricotta
                new Category()
                {
                    Id = GlobalIds.SubCatRicottaId,
                    Name = "Ricotta",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Feta
                new Category()
                {
                    Id = GlobalIds.SubCatFetaId,
                    Name = "Feta",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                //Frischkäse
                new Category()
                {
                    Id = GlobalIds.SubCatFrischkaeseId,
                    Name = "Frischkäse",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Kefir
                new Category()
                {
                    Id = GlobalIds.SubCatKefirId,
                    Name = "Kefir",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Parmesan
                new Category()
                {
                    Id = GlobalIds.SubCatParmesanId,
                    Name = "Parmesan",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Gouda
                new Category()
                {
                    Id = GlobalIds.SubCatGoudaId,
                    Name = "Gouda",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Emmentaler
                new Category()
                {
                    Id = GlobalIds.SubCatEmmentalerId,
                    Name = "Emmentaler",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Brie
                new Category()
                {
                    Id = GlobalIds.SubCatBrieId,
                    Name = "Brie",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Camembert
                new Category()
                {
                    Id = GlobalIds.SubCatCamembertId,
                    Name = "Camembert",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Gorgonzola
                new Category()
                {
                    Id = GlobalIds.SubCatGorgonzolaId,
                    Name = "Gorgonzola",
                    ParentCategoryId = GlobalIds.MainCatMilchProdukteId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },

            };

            foreach (var milchProdukte in milchProdukteSubCategories)
            {
                var existingMilchProdukte = context.Categories.Find(milchProdukte.Id);
                if (existingMilchProdukte == null)
                {
                    context.Categories.Add(milchProdukte);
                }
            }
            context.SaveChanges();
            #endregion

            #region GetraenkeSubCategories

            var getraenkeSubCategories = new List<Category>
            {
                new Category()
                {
                        Id = GlobalIds.SubCatWasserId,
                        Name = "Wasser",
                        ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder"
                    },
                    new Category()
                    {
                       Id = GlobalIds.SubCatBierId,
                       Name = "Bier",
                       ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                       IconId = null,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,
                       CreatedBy = "Seeder"
                    },
                    new Category()
                    {
                       Id = GlobalIds.SubCatWeinId,
                       Name = "Wein",
                       ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                       IconId = null,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,
                       CreatedBy = "Seeder"
                    },
                    new Category()
                    {
                       Id = GlobalIds.SubCatSektId,
                       Name = "Sekt",
                       ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                       IconId = null,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,
                       CreatedBy = "Seeder"
                    },
                    new Category()
                    {
                       Id = GlobalIds.SubCatSaftId,
                       Name = "Saft",
                       ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                       IconId = null,
                       DateCreated = DateTime.Now,
                       DateModified = DateTime.Now,
                       CreatedBy = "Seeder"
                    },
                    new Category()
                    {
                        Id = GlobalIds.SubCatLimonadeId,
                        Name = "Limonade",
                        ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder"
                    },
                   // Schnaps
                   new Category()
                   {
                          Id = GlobalIds.SubCatSchnapsId,
                          Name = "Schnaps",
                          ParentCategoryId = GlobalIds.MainCatGetraenkeId,
                          IconId = null,
                          DateCreated = DateTime.Now,
                          DateModified = DateTime.Now,
                          CreatedBy = "Seeder",
                   },
            };


            foreach (var getraenke in getraenkeSubCategories)
            {
                var existingGetraenke = context.Categories.Find(getraenke.Id);
                if (existingGetraenke == null)
                {
                    context.Categories.Add(getraenke);
                }
            }
            context.SaveChanges();
            #endregion

            #region BackwarenSubCategories

            var backwarenSubCategories = new List<Category>
            {
                // Brot
                new Category()
                {
                    Id = GlobalIds.SubCatBrotId,
                    Name = "Brot",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Semmeln
                new Category()
                {
                    Id = GlobalIds.SubCatSemmelnId,
                    Name = "Semmeln",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Toastbrot
                new Category()
                {
                    Id = GlobalIds.SubCatToastbrotId,
                    Name = "Toastbrot",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Baguette
                new Category()
                {
                    Id = GlobalIds.SubCatBaguetteId,
                    Name = "Baguette",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Kuchen
                new Category()
                {
                    Id = GlobalIds.SubCatKuchenId,
                    Name = "Kuchen",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Torten
                new Category()
                {
                    Id = GlobalIds.SubCatTortenId,
                    Name = "Torten",
                    ParentCategoryId = GlobalIds.MainCatBackwarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
            };

            foreach (var backwaren in backwarenSubCategories)
            {
                var existingBackwaren = context.Categories.Find(backwaren.Id);
                if (existingBackwaren == null)
                {
                    context.Categories.Add(backwaren);
                }
            }

            context.SaveChanges();
            #endregion

            #region SüsswarenSubCategories

            var suesswarenSubCategories = new List<Category>
            {
                // Schokolade
                new Category()
                {
                    Id = GlobalIds.SubCatSchokoladeId,
                    Name = "Schokolade",
                    ParentCategoryId = GlobalIds.MainCatSuesswarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // KekseSuess
                new Category()
                {
                    Id = GlobalIds.SubCatKekseSuessId,
                    Name = "Kekse",
                    ParentCategoryId = GlobalIds.MainCatSuesswarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Bonbons
                new Category()
                {
                    Id = GlobalIds.SubCatBonbonsId,
                    Name = "Bonbons",
                    ParentCategoryId = GlobalIds.MainCatSuesswarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Gummibärchen
                new Category()
                {
                    Id = GlobalIds.SubCatGummibaerchenId,
                    Name = "Gummibärchen",
                    ParentCategoryId = GlobalIds.MainCatSuesswarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Kaugummi
                new Category()
                {
                    Id = GlobalIds.SubCatKaugummiId,
                    Name = "Kaugummi",
                    ParentCategoryId = GlobalIds.MainCatSuesswarenId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
            };

            foreach (var suesswaren in suesswarenSubCategories)
            {
                var existingSuesswaren = context.Categories.Find(suesswaren.Id);
                if (existingSuesswaren == null)
                {
                    context.Categories.Add(suesswaren);
                }
            }

            context.SaveChanges();
            #endregion

            #region TiefkuehlSubCategories

            var tiefKuehlSubCategories = new List<Category>
            {
                    // Pizza
                    new Category()
                    {
                        Id = GlobalIds.SubCatPizzaId,
                        Name = "Pizza",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Fisch
                    new Category()
                    {
                        Id = GlobalIds.SubCatFischTiefkuehlId,
                        Name = "Fisch",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Gemüse
                    new Category()
                    {
                        Id = GlobalIds.SubCatGemueseTiefkuehlId,
                        Name = "Gemüse",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Fleisch
                    new Category()
                    {
                        Id = GlobalIds.SubCatFleischTiefkuehlId,
                        Name = "Fleisch",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Eis
                    new Category()
                    {
                        Id = GlobalIds.SubCatEisId,
                        Name = "Eis",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Pommes
                    new Category()
                    {
                        Id = GlobalIds.SubCatPommesId,
                        Name = "Pommes",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Kuchentiefkühl
                    new Category()
                    {
                        Id = GlobalIds.SubCatKuchenTiefkuehlId,
                        Name = "Kuchen",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    // Feriggerichte
                    new Category()
                    {
                        Id = GlobalIds.SubCatFertiggerichteId,
                        Name = "Fertiggerichte",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
                    //Nuggets
                    new Category()
                    {
                        Id = GlobalIds.SubCatNuggetsId,
                        Name = "Nuggets",
                        ParentCategoryId = GlobalIds.MainCatTiefkuehlId,
                        IconId = null,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        CreatedBy = "Seeder",
                    },
            };

            foreach (var tiefKuehl in tiefKuehlSubCategories)
            {
                var existingTiefKuehl = context.Categories.Find(tiefKuehl.Id);
                if (existingTiefKuehl == null)
                {
                    context.Categories.Add(tiefKuehl);
                }
            }

            context.SaveChanges();
            #endregion

            #region SonstigesSubCategories

            var sonstigesSubCategories = new List<Category>
            {
                // Salz
                new Category()
                {
                    Id = GlobalIds.SubCatSalzId,
                    Name = "Salz",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Pfeffer
                new Category()
                {
                    Id = GlobalIds.SubCatPfefferId,
                    Name = "Pfeffer",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Gewürze
                new Category()
                {
                    Id = GlobalIds.SubCatGewuerzeId,
                    Name = "Gewürze",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Oel
                new Category()
                {
                    Id = GlobalIds.SubCatOelId,
                    Name = "Öl",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Essig
                new Category()
                {
                    Id = GlobalIds.SubCatEssigId,
                    Name = "Essig",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Zucker 
                new Category()
                {
                    Id = GlobalIds.SubCatZuckerId,
                    Name = "Zucker",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Mehl
                new Category()
                {
                    Id = GlobalIds.SubCatMehlId,
                    Name = "Mehl",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Reis
                new Category()
                {
                    Id = GlobalIds.SubCatReisId,
                    Name = "Reis",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Nudeln
                new Category()
                {
                    Id = GlobalIds.SubCatNudelnId,
                    Name = "Nudeln",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Kaffee
                new Category()
                {
                    Id = GlobalIds.SubCatKaffeeId,
                    Name = "Kaffee",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Tee
                new Category()
                {
                    Id = GlobalIds.SubCatTeeId,
                    Name = "Tee",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                new Category()
                {
                    // Kakao
                    Id = GlobalIds.SubCatKakaoId,
                    Name = "Kakao",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Marmelade
                new Category()
                {
                    Id = GlobalIds.SubCatMarmeladeId,
                    Name = "Marmelade",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                //Ketchup
                new Category()
                {
                    Id = GlobalIds.SubCatKetchupId,
                    Name = "Ketchup",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Senf
                new Category()
                {
                    Id = GlobalIds.SubCatSenfId,
                    Name = "Senf",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Mayonnaise
                new Category()
                {
                    Id = GlobalIds.SubCatMayonnaiseId,
                    Name = "Mayonnaise",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Honig
                new Category()
                {
                    Id = GlobalIds.SubCatHonigId,
                    Name = "Honig",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Nüsse
                new Category()
                {
                    Id = GlobalIds.SubCatNuesseId,
                    Name = "Nüsse",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                //Muesli
                new Category()
                {
                    Id = GlobalIds.SubCatMuesliId,
                    Name = "Müsli",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Sauce
                new Category()
                {
                    Id = GlobalIds.SubCatSauceId,
                    Name = "Sauce",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                //Suppe
                new Category()
                {
                    Id = GlobalIds.SubCatSuppeId,
                    Name = "Suppe",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                },
                // Chips
                new Category()
                {
                    Id = GlobalIds.SubCatKartoffelchipsId,
                    Name = "Chips",
                    ParentCategoryId = GlobalIds.MainCatSonstigesId,
                    IconId = null,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    CreatedBy = "Seeder",
                }

            };

            foreach (var sonstiges in sonstigesSubCategories)
            {
                var existingSonstiges = context.Categories.Find(sonstiges.Id);
                if (existingSonstiges == null)
                {
                    context.Categories.Add(sonstiges);
                }
            }

            context.SaveChanges();
            #endregion
        }
    }
}
