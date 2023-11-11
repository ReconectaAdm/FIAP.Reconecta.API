using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Residue;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class ResidueRepository : IResidueRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ResidueRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base
        public IEnumerable<Residue> Get()
        {
            return dataBaseContext.Residue;
        }

        public IEnumerable<Residue> Get(int organizationId)
        {
            return dataBaseContext.Residue.Where(r => r.OrganizationId == organizationId);
        }

        public Residue? GetById(int id)
        {
            return dataBaseContext.Residue.AsNoTracking().FirstOrDefault(r => r.Id == id);
        }

        public void Add(Residue residue)
        {
            dataBaseContext.Residue.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Residue> residues)
        {
            dataBaseContext.Residue.AddRange(residues);
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
        #endregion
    }
}
