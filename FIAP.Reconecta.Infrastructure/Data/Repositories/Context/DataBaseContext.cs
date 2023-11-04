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

            modelBuilder.Entity<Company>()
             .HasMany(c => c.Addresses)
             .WithOne(s => s.Empresa)
             .HasForeignKey(k => k.EmpresaId);

            modelBuilder.Entity<CompanyFavorite>().HasKey(k => new { k.EstablishmentId, k.OrganizationId });

            modelBuilder.Entity<Company>()
             .HasMany(cf => cf.Favorites)
             .WithOne(cf => cf.Organization)
             .HasForeignKey(k => k.OrganizationId);
        }

    }
}
