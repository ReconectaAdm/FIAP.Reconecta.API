using FIAP.Reconecta.Contracts.Models;
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
            return dataBaseContext.Collect.Include(c => c.Residues);
        }

        public Collect? GetById(int id)
        {
            var collection = dataBaseContext.Collect.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
            return collection;
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

        public void AddRange(IEnumerable<Collect> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var collection = new Collect { Id = id };
            dataBaseContext.Collect.Remove(collection);
            dataBaseContext.SaveChanges();
        }
    }
}