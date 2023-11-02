using FIAP.Reconecta.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyAddress> CompanyAddress { get; set; }

        public DbSet<Collect> Collect { get; set; }

        public DbSet<Residue> Residue { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
             .HasMany(c => c.Enderecos)
             .WithOne(s => s.Empresa)
             .HasForeignKey(k => k.EmpresaId);
        }

    }
}
