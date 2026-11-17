
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
        public DbSet<ParametresApplication> ParametresApplication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Précision des décimaux
            modelBuilder.Entity<Voiture>()
                .Property(v => v.PrixAchat)
                .HasPrecision(18, 2);

            // Relation Voiture - Photo
            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Voiture)
                .WithMany(v => v.Photos)
                .HasForeignKey(p => p.VoitureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reparation>()
                .Property(r => r.CoutReparation)
                .HasPrecision(18, 2);

            // Relation Modele - ModeleFinition
            modelBuilder.Entity<ModeleFinition>()
                .HasOne(mf => mf.Modele)
                .WithMany(m => m.ModeleFinitions)
                .HasForeignKey(mf => mf.ModeleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation Finition - ModeleFinition
            modelBuilder.Entity<ModeleFinition>()
                .HasOne(mf => mf.Finition)
                .WithMany(f => f.ModeleFinitions)
                .HasForeignKey(mf => mf.FinitionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Empêcher les associations en double
            modelBuilder.Entity<ModeleFinition>()
                .HasIndex(mf => new { mf.ModeleId, mf.FinitionId })
                .IsUnique();

            // Paramètres de l'application
            modelBuilder.Entity<ParametresApplication>()
                .Property(p => p.MargeBenefice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ParametresApplication>()
                .HasData(new ParametresApplication
                {
                    Id = 1,
                    MargeBenefice = 500m
                });
        }
    }
}
