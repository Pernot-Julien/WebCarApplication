
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Models.Entities;

namespace WebCarApplication.Data
{
    public static class DatabaseSeeder
    {
        public static async Task InitializeAsync(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            // Appliquer les migrations
            await context.Database.MigrateAsync();
            await AjouterUtilisateurAdminAsync(userManager);

            // Création des marques et de leurs modèles
            if (!await context.Marques.AnyAsync())
            {
                var bmw = new Marque
                {
                    NomMarque = "BMW",
                    Modeles =
                    {
                        new Modele { NomModele = "Série 3" },
                        new Modele { NomModele = "Série 4" },
                        new Modele { NomModele = "Série 5" }
                    }
                };

                var audi = new Marque
                {
                    NomMarque = "Audi",
                    Modeles =
                    {
                        new Modele { NomModele = "A3" },
                        new Modele { NomModele = "A4" },
                        new Modele { NomModele = "A5" }
                    }
                };

                var porsche = new Marque
                {
                    NomMarque = "Porsche",
                    Modeles =
                    {
                        new Modele { NomModele = "911" },
                        new Modele { NomModele = "718 Cayman" }
                    }
                };

                var mercedes = new Marque
                {
                    NomMarque = "Mercedes-AMG",
                    Modeles =
                    {
                        new Modele { NomModele = "Classe C" },
                        new Modele { NomModele = "AMG GT" }
                    }
                };

                var alfaRomeo = new Marque
                {
                    NomMarque = "Alfa Romeo",
                    Modeles = { new Modele { NomModele = "Giulia" } }
                };

                var nissan = new Marque
                {
                    NomMarque = "Nissan",
                    Modeles = { new Modele { NomModele = "GT-R" } }
                };

                var toyota = new Marque
                {
                    NomMarque = "Toyota",
                    Modeles = { new Modele { NomModele = "GR Supra" } }
                };

                var ford = new Marque
                {
                    NomMarque = "Ford",
                    Modeles = { new Modele { NomModele = "Mustang" } }
                };

                var chevrolet = new Marque
                {
                    NomMarque = "Chevrolet",
                    Modeles = { new Modele { NomModele = "Corvette C8" } }
                };

                var mclaren = new Marque
                {
                    NomMarque = "McLaren",
                    Modeles = { new Modele { NomModele = "570S" } }
                };

                var lamborghini = new Marque
                {
                    NomMarque = "Lamborghini",
                    Modeles = { new Modele { NomModele = "Huracán" } }
                };

                context.Marques.AddRange(
                    bmw, audi, porsche, mercedes, alfaRomeo,
                    nissan, toyota, ford, chevrolet, mclaren, lamborghini
                );

                await context.SaveChangesAsync();
            }

            // Créer les finitions et leurs associations
            await AjouterFinitionsAsync(context);

            // Créer les voitures
            await AjouterVoituresAsync(context);

            // Créer les réparations
            await AjouterReparationsAsync(context);

            await AjouterPhotosAsync(context);
        }

        private static async Task AjouterReparationsAsync(ApplicationDbContext context)
        {
            if (await context.Reparations.AnyAsync())
                return;

            var voitures = await context.Voitures
                .Include(v => v.ModeleFinition)
                    .ThenInclude(mf => mf.Modele)
                        .ThenInclude(m => m.Marque)
                .ToListAsync();

            var reparations = new List<Reparation>();

            void Ajouter(string marque, string modele, string description, decimal cout)
            {
                var voiture = voitures.First(v =>
                    v.ModeleFinition.Modele.Marque!.NomMarque == marque &&
                    v.ModeleFinition.Modele.NomModele == modele);

                reparations.Add(new Reparation
                {
                    DescriptionReparation = description,
                    CoutReparation = cout,
                    Voiture = voiture
                });
            }

            // BMW
            Ajouter("BMW", "Série 3", "Remplacement des plaquettes de frein avant", 850m);
            Ajouter("BMW", "Série 5", "Révision moteur et remplacement des filtres", 1200m);

            // Audi
            Ajouter("Audi", "A3", "Remplacement des pneumatiques", 1100m);

            // Porsche
            Ajouter("Porsche", "911", "Remplacement des disques et plaquettes de frein", 2400m);

            // Mercedes-AMG
            Ajouter("Mercedes-AMG", "Classe C", "Révision complète et vidange", 950m);

            // Nissan
            Ajouter("Nissan", "GT-R", "Remplacement de l'embrayage", 4800m);

            context.Reparations.AddRange(reparations);
            await context.SaveChangesAsync();
        }

        private static async Task AjouterVoituresAsync(ApplicationDbContext context)
        {
            if (await context.Voitures.AnyAsync())
                return;

            var voitures = new List<Voiture>
    {
        // BMW
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 1, 15),
            PrixAchat = 68000m,
            Description = "BMW M3 Competition, berline sportive et performante.",
            ModeleFinition = RecupererModeleFinition(context, "BMW", "Série 3", "M3 Competition")
        },
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 2, 10),
            PrixAchat = 82000m,
            Description = "BMW M4 Competition, coupé sportif hautes performances.",
            ModeleFinition = RecupererModeleFinition(context, "BMW", "Série 4", "M4 Competition")
        },
        new Voiture
        {
            Annee = 2021,
            DateAchat = new DateTime(2026, 3, 5),
            PrixAchat = 105000m,
            Description = "BMW M5 Competition, grande berline sportive.",
            ModeleFinition = RecupererModeleFinition(context, "BMW", "Série 5", "M5 Competition")
        },

        // Audi
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 1, 20),
            PrixAchat = 55000m,
            Description = "Audi RS3, compacte sportive à transmission intégrale.",
            ModeleFinition = RecupererModeleFinition(context, "Audi", "A3", "RS3")
        },
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 2, 18),
            PrixAchat = 65000m,
            Description = "Audi RS4, break sportif et polyvalent.",
            ModeleFinition = RecupererModeleFinition(context, "Audi", "A4", "RS4")
        },
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 3, 12),
            PrixAchat = 72000m,
            Description = "Audi RS5, coupé sportif et élégant.",
            ModeleFinition = RecupererModeleFinition(context, "Audi", "A5", "RS5")
        },

        // Porsche
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 1, 25),
            PrixAchat = 125000m,
            Description = "Porsche 911 Carrera S, sportive emblématique.",
            ModeleFinition = RecupererModeleFinition(context, "Porsche", "911", "Carrera S")
        },
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 4, 8),
            PrixAchat = 145000m,
            Description = "Porsche 718 Cayman GT4 RS, sportive radicale orientée circuit.",
            ModeleFinition = RecupererModeleFinition(context, "Porsche", "718 Cayman", "GT4 RS")
        },

        // Mercedes-AMG
        new Voiture
        {
            Annee = 2021,
            DateAchat = new DateTime(2026, 2, 5),
            PrixAchat = 72000m,
            Description = "Mercedes-AMG C63 S, berline sportive au caractère affirmé.",
            ModeleFinition = RecupererModeleFinition(context, "Mercedes-AMG", "Classe C", "C63 S")
        },
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 3, 20),
            PrixAchat = 105000m,
            Description = "Mercedes-AMG GT 63 S, coupé quatre portes hautes performances.",
            ModeleFinition = RecupererModeleFinition(context, "Mercedes-AMG", "AMG GT", "GT 63 S")
        },

        // Alfa Romeo
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 4, 15),
            PrixAchat = 62000m,
            Description = "Alfa Romeo Giulia Quadrifoglio, berline sportive italienne.",
            ModeleFinition = RecupererModeleFinition(context, "Alfa Romeo", "Giulia", "Quadrifoglio")
        },

        // Nissan
        new Voiture
        {
            Annee = 2020,
            DateAchat = new DateTime(2026, 5, 2),
            PrixAchat = 95000m,
            Description = "Nissan GT-R, sportive japonaise à transmission intégrale.",
            ModeleFinition = RecupererModeleFinition(context, "Nissan", "GT-R", "Premium Edition")
        },

        // Toyota
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 5, 10),
            PrixAchat = 58000m,
            Description = "Toyota GR Supra 3.0, coupé sportif propulsion.",
            ModeleFinition = RecupererModeleFinition(context, "Toyota", "GR Supra", "3.0 Performance")
        },

        // Ford
        new Voiture
        {
            Annee = 2024,
            DateAchat = new DateTime(2026, 5, 18),
            PrixAchat = 65000m,
            Description = "Ford Mustang Dark Horse, muscle car orientée performances.",
            ModeleFinition = RecupererModeleFinition(context, "Ford", "Mustang", "Dark Horse")
        },

        // Chevrolet
        new Voiture
        {
            Annee = 2023,
            DateAchat = new DateTime(2026, 6, 1),
            PrixAchat = 92000m,
            Description = "Chevrolet Corvette C8 Stingray, sportive américaine à moteur central.",
            ModeleFinition = RecupererModeleFinition(context, "Chevrolet", "Corvette C8", "Stingray")
        },

        // McLaren
        new Voiture
        {
            Annee = 2020,
            DateAchat = new DateTime(2026, 6, 12),
            PrixAchat = 115000m,
            Description = "McLaren 570S, sportive britannique légère et performante.",
            ModeleFinition = RecupererModeleFinition(context, "McLaren", "570S", "570S")
        },

        // Lamborghini
        new Voiture
        {
            Annee = 2022,
            DateAchat = new DateTime(2026, 6, 20),
            PrixAchat = 205000m,
            Description = "Lamborghini Huracán EVO, supercar italienne à moteur V10.",
            ModeleFinition = RecupererModeleFinition(context, "Lamborghini", "Huracán", "EVO")
        }
    };

            context.Voitures.AddRange(voitures);

            await context.SaveChangesAsync();
        }

        private static async Task AjouterFinitionsAsync(ApplicationDbContext context)
        {
            if (await context.ModeleFinitions.AnyAsync())
                return;

            var modeles = await context.Modeles
                .Include(m => m.Marque)
                .ToListAsync();

            var associations = new List<ModeleFinition>();

            void Ajouter(string marque, string modele, params string[] finitions)
            {
                var modeleTrouve = modeles.First(m =>
                    m.Marque!.NomMarque == marque &&
                    m.NomModele == modele);

                foreach (var nomFinition in finitions)
                {
                    var finition = context.Finitions.Local
                        .FirstOrDefault(f => f.NomFinition == nomFinition);

                    if (finition == null)
                    {
                        finition = new Finition { NomFinition = nomFinition };
                        context.Finitions.Add(finition);
                    }

                    associations.Add(new ModeleFinition
                    {
                        Modele = modeleTrouve,
                        Finition = finition
                    });
                }
            }

            // BMW
            Ajouter("BMW", "Série 3", "M3", "M3 Competition", "M3 CS");
            Ajouter("BMW", "Série 4", "M4", "M4 Competition", "M4 CSL");
            Ajouter("BMW", "Série 5", "M5", "M5 Competition", "M5 CS");

            // Audi
            Ajouter("Audi", "A3", "RS3", "RS3 Carbon Edition", "RS3 Performance");
            Ajouter("Audi", "A4", "RS4", "RS4 Carbon Edition", "RS4 Competition");
            Ajouter("Audi", "A5", "RS5", "RS5 Carbon Edition", "RS5 Competition Plus");

            // Porsche
            Ajouter("Porsche", "911", "Carrera", "Carrera S", "GTS", "Turbo S", "GT3");
            Ajouter("Porsche", "718 Cayman", "GT4 RS");

            // Mercedes-AMG
            Ajouter("Mercedes-AMG", "Classe C", "C63 S");
            Ajouter("Mercedes-AMG", "AMG GT", "GT 63 S");

            // Alfa Romeo
            Ajouter("Alfa Romeo", "Giulia", "Quadrifoglio");

            // Nissan
            Ajouter("Nissan", "GT-R", "Premium Edition");

            // Toyota
            Ajouter("Toyota", "GR Supra", "3.0 Performance");

            // Ford
            Ajouter("Ford", "Mustang", "Dark Horse");

            // Chevrolet
            Ajouter("Chevrolet", "Corvette C8", "Stingray");

            // McLaren
            Ajouter("McLaren", "570S", "570S");

            // Lamborghini
            Ajouter("Lamborghini", "Huracán", "EVO");

            context.ModeleFinitions.AddRange(associations);

            await context.SaveChangesAsync();
        }

        private static ModeleFinition RecupererModeleFinition(
            ApplicationDbContext context,
            string marque,
            string modele,
            string finition)
        {
            return context.ModeleFinitions
                .Include(mf => mf.Modele)
                    .ThenInclude(m => m.Marque)
                .Include(mf => mf.Finition)
                .First(mf =>
                    mf.Modele.Marque!.NomMarque == marque &&
                    mf.Modele.NomModele == modele &&
                    mf.Finition.NomFinition == finition);
        }

        private static async Task AjouterUtilisateurAdminAsync(
        UserManager<IdentityUser> userManager)
        {
            const string email = "admin@admin.com";
            const string password = "Admin123!";

            var utilisateur = await userManager.FindByEmailAsync(email);

            if (utilisateur == null)
            {
                utilisateur = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var resultat = await userManager.CreateAsync(utilisateur, password);

                if (!resultat.Succeeded)
                {
                    throw new Exception(
                        string.Join(", ", resultat.Errors.Select(e => e.Description)));
                }
            }
        }
        private static async Task AjouterPhotosAsync(ApplicationDbContext context)
        {
            if (await context.Photos.AnyAsync())
                return;

            {
                var correspondances = new List<(string Marque, string Url, string Alt, string Modele, string Finition)>
{
    ("McLaren", "/images/voitures/570.jpg", "McLaren 570S", "570S", "570S"),
    ("Porsche", "/images/voitures/911.jpg", "Porsche 911 Carrera S", "911", "Carrera S"),
    ("Mercedes-AMG", "/images/voitures/amggt.jpg", "Mercedes-AMG GT 63 S", "AMG GT", "GT 63 S"),
    ("Mercedes-AMG", "/images/voitures/c63.jpg", "Mercedes-AMG C63 S", "Classe C", "C63 S"),
    ("Chevrolet", "/images/voitures/corvette.jpg", "Chevrolet Corvette C8 Stingray", "Corvette C8", "Stingray"),
    ("Alfa Romeo", "/images/voitures/giulia.jpg", "Alfa Romeo Giulia Quadrifoglio", "Giulia", "Quadrifoglio"),
    ("Porsche", "/images/voitures/gt4rs.jpg", "Porsche 718 Cayman GT4 RS", "718 Cayman", "GT4 RS"),
    ("Nissan", "/images/voitures/gtr.jpg", "Nissan GT-R", "GT-R", "Premium Edition"),
    ("Lamborghini", "/images/voitures/huracan.jpg", "Lamborghini Huracán EVO", "Huracán", "EVO"),
    ("BMW", "/images/voitures/m3.jpg", "BMW M3 Competition", "Série 3", "M3 Competition"),
    ("BMW", "/images/voitures/m4.jpg", "BMW M4 Competition", "Série 4", "M4 Competition"),
    ("BMW", "/images/voitures/m5.jpg", "BMW M5 Competition", "Série 5", "M5 Competition"),
    ("Ford", "/images/voitures/mustang.jpg", "Ford Mustang Dark Horse", "Mustang", "Dark Horse"),
    ("Audi", "/images/voitures/rs3.jpg", "Audi RS3", "A3", "RS3"),
    ("Audi", "/images/voitures/rs4.jpg", "Audi RS4", "A4", "RS4"),
    ("Audi", "/images/voitures/rs5.jpg", "Audi RS5", "A5", "RS5"),
    ("Toyota", "/images/voitures/supra.jpg", "Toyota GR Supra", "GR Supra", "3.0 Performance")
};


                var photos = new List<Photo>();

                foreach (var correspondance in correspondances)
                {
                    var modeleFinition = await context.ModeleFinitions
                        .Include(mf => mf.Modele)
                        .ThenInclude(m => m.Marque)
                        .Include(mf => mf.Finition)
                        .FirstOrDefaultAsync(mf =>
                            mf.Modele.Marque!.NomMarque == correspondance.Marque &&
                            mf.Modele.NomModele == correspondance.Modele &&
                            mf.Finition.NomFinition == correspondance.Finition);

                    if (modeleFinition == null)
                        throw new Exception(
                            $"Association introuvable : {correspondance.Modele} - {correspondance.Finition}");

                    var voiture = await context.Voitures
                        .FirstOrDefaultAsync(v => v.ModeleFinitionId == modeleFinition.Id);

                    if (voiture == null)
                        throw new Exception(
                            $"Voiture introuvable : {correspondance.Modele} - {correspondance.Finition}");

                    photos.Add(new Photo
                    {
                        Url = correspondance.Url,
                        TexteAlternatif = correspondance.Alt,
                        VoitureId = voiture.Id
                    });
                }

                await context.Photos.AddRangeAsync(photos);
                await context.SaveChangesAsync();
            }
        }
    }
}
