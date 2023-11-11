using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class CompanyAvailabilityRepository : ICompanyAvailabilityRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyAvailabilityRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base

        public IEnumerable<CompanyAvailability> Get()
        {
            return dataBaseContext.CompanyAvailability;
        }

        public CompanyAvailability? GetById(int id)
        {
            return dataBaseContext.CompanyAvailability.AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(CompanyAvailability companyAvailability)
        {
            dataBaseContext.CompanyAvailability.Add(companyAvailability);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<CompanyAvailability> companyAvailability)
        {
            dataBaseContext.CompanyAvailability.AddRange(companyAvailability);
            dataBaseContext.SaveChanges();
        }

        public void Update(CompanyAvailability companyAvailability)
        {
            dataBaseContext.CompanyAvailability.Update(companyAvailability);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var companyAvailability = new CompanyAvailability { Id = id };
            dataBaseContext.CompanyAvailability.Remove(companyAvailability);
            dataBaseContext.SaveChanges();
        }

        #endregion

        public void UpdateRange(IEnumerable<CompanyAvailability> companyAvailability)
        {
            dataBaseContext.CompanyAvailability.UpdateRange(companyAvailability);
            dataBaseContext.SaveChanges();
        }

        public IEnumerable<CompanyAvailability> GetByCompanyId(int companyId)
        {
            return dataBaseContext.CompanyAvailability.Where(ca => ca.CompanyId == companyId);
        }

    }
}