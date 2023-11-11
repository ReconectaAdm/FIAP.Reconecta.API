using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Residue;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class ResidueTypeRepository : IResidueTypeRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ResidueTypeRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<ResidueType> Get()
        {
            return dataBaseContext.ResidueType;
        }

        public ResidueType? GetById(int id)
        {
            return dataBaseContext.ResidueType.AsNoTracking().FirstOrDefault(rt => rt.Id == id);
        }

        public void Add(ResidueType residue)
        {
            dataBaseContext.ResidueType.Add(residue);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<ResidueType> residueTypes)
        {
            dataBaseContext.ResidueType.AddRange(residueTypes);
            dataBaseContext.SaveChanges();
        }

        public void Update(ResidueType residue)
        {
            dataBaseContext.ResidueType.Update(residue);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var residue = new ResidueType { Id = id };
            dataBaseContext.ResidueType.Remove(residue);
            dataBaseContext.SaveChanges();
        }
    }
}
