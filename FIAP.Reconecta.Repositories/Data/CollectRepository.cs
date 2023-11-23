using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FIAP.Reconecta.Repositories.Data
{
    public class CollectRepository : ICollectRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CollectRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base
        public IEnumerable<Collect> Get()
        {
            return dataBaseContext.Collect
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                 .Include(c => c.Organization);
        }

        public IEnumerable<Collect> Get(CollectStatus status)
        {
            return dataBaseContext.Collect.Where(c => c.Status == status)
                .Include(c => c.Residues)
                .Include(c => c.Establishment)
                .Include(c => c.Organization);
        }

        public Collect? GetById(int id)
        {
            var collection = dataBaseContext.Collect.AsNoTracking()
                 .Include(c => c.Residues)!
                    .ThenInclude(cr => cr.Residue)
                 .Include(c => c.Establishment)
                 .Include(c => c.Organization)
                 .Include(c => c.Rating)
                 .FirstOrDefault(c => c.Id == id);

            return collection;
        }

        public Collect? GetById(int id, int companyId)
        {
            var collection = dataBaseContext.Collect.AsNoTracking()
                 .Include(c => c.Residues)!
                    .ThenInclude(cr => cr.Residue)
                 .Include(c => c.Establishment)
                 .Include(c => c.Organization)
                 .Include(c => c.Rating)
                 .FirstOrDefault(c => c.OrganizationId == companyId || c.EstablishmentId == companyId && c.Id == id);

            return collection;
        }

        public void Add(Collect collection)
        {
            dataBaseContext.Collect.Add(collection);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Collect> collections)
        {
            dataBaseContext.Collect.AddRange(collections);
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

        #endregion

        public IEnumerable<Collect> GetByCompanyId(int companyId)
        {
            return dataBaseContext.Collect
                 .Where(c => c.EstablishmentId == companyId || c.OrganizationId == companyId)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> GetByCompanyId(int companyId, CollectStatus status)
        {
            return dataBaseContext.Collect
                 .Where(c => c.EstablishmentId == companyId || c.OrganizationId == companyId && c.Status == status)
                 .Include(c => c.Residues)
                 .Include(c => c.Establishment)
                     .ThenInclude(e => e.Addresses)
                 .Include(c => c.Organization)
                     .ThenInclude(o => o.Addresses);
        }

        public IEnumerable<Collect> GetSummary(int companyId)
        {
            return dataBaseContext.Collect
                .Where(c => c.OrganizationId == companyId || c.EstablishmentId == companyId)
                .Include(c => c.Residues)!
                    .ThenInclude(cr => cr.Residue)
                    .ThenInclude(r => r.Type);
        }

        public IEnumerable<Collect> GetSummary(int companyId, DateTime initialDate, DateTime endDate)
        {
            return dataBaseContext.Collect
                .Where(c => c.OrganizationId == companyId || c.EstablishmentId == companyId && 
                       c.CreationDate >= initialDate && c.CreationDate <= endDate)
                .Include(c => c.Residues)!
                    .ThenInclude(cr => cr.Residue)
                    .ThenInclude(r => r.Type);
        }

        public void UpdateStatus(Collect collect)
        {
            dataBaseContext.Entry(collect).Property(c => c.Status).IsModified = true;
            dataBaseContext.SaveChanges();
        }
    }
}