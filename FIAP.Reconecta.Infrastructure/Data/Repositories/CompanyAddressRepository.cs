using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class CompanyAddressRepository : ICompanyAddressRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyAddressRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base

        public IEnumerable<CompanyAddress> Get()
        {
            return dataBaseContext.CompanyAddress;
        }

        public CompanyAddress? GetById(int id)
        {
            return dataBaseContext.CompanyAddress.AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(CompanyAddress company)
        {
            dataBaseContext.CompanyAddress.Add(company);
            dataBaseContext.SaveChanges();
        }

        public void Update(CompanyAddress company)
        {
            dataBaseContext.CompanyAddress.Update(company);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = new CompanyAddress { Id = id };
            dataBaseContext.CompanyAddress.Remove(company);
            dataBaseContext.SaveChanges();
        }

        #endregion
    }
}