using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Contracts.Models.User;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }
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
            modelBuilder.Entity<CompanyResidue>().HasKey(k => new { k.ResidueId, k.OrganizationId });

            //modelBuilder.Entity<Company>()
            //   .HasMany(c => c.Addresses)
            //   .WithOne(s => s.Company)
            //   .HasForeignKey(k => k.CompanyId);

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Favorites)
               .WithOne(cf => cf.Organization)
               .HasForeignKey(k => k.OrganizationId);

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Residues)
               .WithOne(cr => cr.Organization)
               .HasForeignKey(k => k.OrganizationId);

            modelBuilder.Entity<Company>()
               .HasMany(c => c.Points)
               .WithOne(ca => ca.Company)
               .HasForeignKey(k => k.CompanyId);

            modelBuilder.Entity<Company>()
               .HasOne(c => c.Availability)
               .WithOne(ca => ca.Company);

            //modelBuilder.Entity<Organization>()
            //   .HasMany(c => c.Collects)
            //   .WithOne(r => r.Organization)
            //   .HasForeignKey(k => k.OrganizationId);

            //modelBuilder.Entity<Establishment>()
            //   .HasMany(c => c.Collects)
            //   .WithOne(r => r.Establishment)
            //   .HasForeignKey(k => k.EstablishmentId);

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

            #region User

            //modelBuilder.Entity<User>()
            //  .HasOne(c => c.Company)
            //  .WithOne(u => u.User);

            #endregion
        }

    }
}
