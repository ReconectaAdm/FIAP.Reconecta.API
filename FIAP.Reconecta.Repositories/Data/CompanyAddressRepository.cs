using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
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

        public void Add(CompanyAddress companyAddress)
        {
            dataBaseContext.CompanyAddress.Add(companyAddress);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<CompanyAddress> companyAddresses)
        {
            dataBaseContext.CompanyAddress.AddRange(companyAddresses);
            dataBaseContext.SaveChanges();
        }

        public void Update(CompanyAddress companyAddress)
        {
            dataBaseContext.CompanyAddress.Update(companyAddress);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var companyAddress = new CompanyAddress { Id = id };
            dataBaseContext.CompanyAddress.Remove(companyAddress);
            dataBaseContext.SaveChanges();
        }

        #endregion
    }
}