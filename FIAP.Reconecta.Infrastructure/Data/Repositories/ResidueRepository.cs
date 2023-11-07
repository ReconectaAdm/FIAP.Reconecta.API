using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class ResidueRepository : IResidueRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ResidueRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<Residue> Get()
        {
            return dataBaseContext.Residue;
        }

        public Residue? GetById(int id)
        {
            return dataBaseContext.Residue.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public void Add(Residue residue)
        {
            dataBaseContext.Residue.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Residue> residue)
        {
            dataBaseContext.Residue.AddRange(residue);
            dataBaseContext.SaveChanges();
        }

        public void Update(Residue residue)
        {
            dataBaseContext.Residue.Update(residue);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var residue = new Residue { Id = id };
            dataBaseContext.Residue.Remove(residue);
            dataBaseContext.SaveChanges();
        }
    }
}
