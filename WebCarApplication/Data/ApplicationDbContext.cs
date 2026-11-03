using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Models.Entities;

namespace WebCarApplication.Data
    {
        public class ApplicationDbContext : IdentityDbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Voiture> Voitures { get; set; }
            public DbSet<Photo> Photos { get; set; }
            public DbSet<Finition> Finitions { get; set; }
            public DbSet<Modele> Modeles { get; set; }
            public DbSet<Marque> Marques { get; set; }
            public DbSet<Reparation> Reparations { get; set; }
        }
    }