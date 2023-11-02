using FIAP.Reconecta.Contracts.Models;
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

    }
}
