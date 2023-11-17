using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Entities.Payment;
using FIAP.Reconecta.Models.Entities.Residue;
using FIAP.Reconecta.Models.Entities.User;
using FIAP.Reconecta.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FIAP.Reconecta.Repositories.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }
        public DbSet<CompanyAvailability> CompanyAvailability { get; set; }
        public DbSet<CompanyFavorite> CompanyFavorite { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Collect> Collect { get; set; }
        public DbSet<CollectRating> CollectRating { get; set; }
        public DbSet<Residue> Residue { get; set; }
        public DbSet<ResidueType> ResidueType { get; set; }
        public DbSet<EstablishmentPayment> EstablishmentPayment { get; set; }
        public DbSet<OrganizationPayment> OrganizationPayment { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Company

            modelBuilder.Entity<Company>().HasDiscriminator<CompanyType>("Type")
              .HasValue<Company>(CompanyType.BASE)
              .HasValue<Organization>(CompanyType.ORGANIZATION)
              .HasValue<Establishment>(CompanyType.ESTABLISHMENT);

            modelBuilder.Entity<CompanyFavorite>().HasKey(k => new { k.EstablishmentId, k.OrganizationId });

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Favorites)
               .WithOne(cf => cf.Organization)
               .HasForeignKey(k => k.OrganizationId);

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Residues)
               .WithOne(cr => cr.Organization)
               .HasForeignKey(k => k.OrganizationId);

            modelBuilder.Entity<Company>()
               .HasOne(c => c.Availability)
               .WithOne(ca => ca.Company);

            #endregion

            #region Collect

            modelBuilder.Entity<Collect>()
              .HasMany(c => c.Residues)
              .WithOne(r => r.Collect)
              .HasForeignKey(k => k.CollectId);

            modelBuilder.Entity<Collect>()
              .HasOne(c => c.Organization)
              .WithMany(r => r.Collects)
              .HasForeignKey(k => k.OrganizationId);

            modelBuilder.Entity<Collect>()
              .HasOne(c => c.Establishment)
              .WithMany(r => r.Collects)
              .HasForeignKey(k => k.EstablishmentId);

            modelBuilder.Entity<Collect>()
               .HasOne(c => c.Rating)
               .WithOne(r => r.Collect);

            #endregion
        }

    }
}
