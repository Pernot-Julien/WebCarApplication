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
            public DbSet<ModeleFinition> ModeleFinitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Précisions pour les décimaux
            modelBuilder.Entity<Voiture>()
                .Property(v => v.PrixAchat)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Reparation>()
                .Property(r => r.CoutReparation)
                .HasPrecision(18, 2);

            // Configuration de la table de jonction ModeleFinition (Crucial pour éviter l'erreur de cascade)
            modelBuilder.Entity<ModeleFinition>()
                 .HasOne(mf => mf.Modele)
                 .WithMany(m => m.ModeleFinitions) 
                 .HasForeignKey(mf => mf.ModeleId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ModeleFinition>()
                .HasOne(mf => mf.Finition)
                .WithMany(f => f.ModeleFinitions) 
                .HasForeignKey(mf => mf.FinitionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    }