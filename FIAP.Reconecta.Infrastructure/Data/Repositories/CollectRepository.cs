using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class CollectRepository : ICollectRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CollectRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<Collect> Get()
        {
            return dataBaseContext.Collect
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> Get(CollectStatus status)
        {
            return dataBaseContext.Collect.Where(c => c.Status == (int)status)
                .Include(c => c.Residues)
                .Include(c => c.Establishment)
                    .ThenInclude(e => e.Addresses)
                .Include(c => c.Organization)
                    .ThenInclude(o => o.Addresses);
        }

        public Collect? GetById(int id)
        {
            var collection = dataBaseContext.Collect.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
            return collection;
        }

        public IEnumerable<Collect> GetByOrganizationId(int organizationId)
        {
            return dataBaseContext.Collect
                 .Where(c => c.OrganizationId == organizationId)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> GetByOrganizationId(int organizationId, CollectStatus status)
        {
            return dataBaseContext.Collect
                 .Where(c => c.OrganizationId == organizationId && c.Status == (int)status)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> GetByEstablishmentId(int establishmentId)
        {
            return dataBaseContext.Collect
                 .Where(c => c.EstablishmentId == establishmentId)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> GetByEstablishmentId(int establishmentId, CollectStatus status)
        {
            return dataBaseContext.Collect
                 .Where(c => c.EstablishmentId == establishmentId && c.Status == (int)status)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public void Add(Collect collection)
        {
            dataBaseContext.Collect.Add(collection);
            dataBaseContext.SaveChanges();
        }

        public void Update(Collect collection)
        {
            dataBaseContext.Collect.Update(collection);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var collection = new Collect { Id = id };
            dataBaseContext.Collect.Remove(collection);
            dataBaseContext.SaveChanges();
        }
    }
}