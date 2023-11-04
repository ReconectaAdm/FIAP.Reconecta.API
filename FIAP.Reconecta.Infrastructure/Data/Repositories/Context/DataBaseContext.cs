using FIAP.Reconecta.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }

        public DbSet<Collect> Collect { get; set; }

        public DbSet<Residue> Residue { get; set; }

        public DbSet<ResidueType> ResidueType { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Company

            modelBuilder.Entity<CompanyFavorite>().HasKey(k => new { k.EstablishmentId, k.OrganizationId });
            modelBuilder.Entity<CompanyResidue>().HasKey(k => new { k.ResidueId, k.OrganizationId });

            modelBuilder.Entity<Company>()
             .HasMany(c => c.Addresses)
             .WithOne(s => s.Company)
             .HasForeignKey(k => k.CompanyId);

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

            #endregion
        }

    }
}
