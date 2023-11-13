using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base

        public virtual IEnumerable<Company> Get()
        {
            return dataBaseContext.Company.Include(c => c.Addresses);
        }

        public virtual Company? GetById(int id)
        {
            return dataBaseContext.Company.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public virtual void Add(Company company)
        {
            dataBaseContext.Company.Add(company);
            dataBaseContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<Company> companies)
        {
            dataBaseContext.Company.AddRange(companies);
            dataBaseContext.SaveChanges();
        }

        public virtual void Update(Company company)
        {
            dataBaseContext.Company.Update(company);
            dataBaseContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var company = new Company { Id = id };
            dataBaseContext.Company.Remove(company);
            dataBaseContext.SaveChanges();
        }

        #endregion

        public byte[]? GetLogo(int companyId)
        {
            return dataBaseContext.Company.AsNoTracking().FirstOrDefault(c => c.Id == companyId)?.Logo;
        }

        public void UpdateLogo(Company company)
        {
            dataBaseContext.Entry(company).Property(c => c.Logo).IsModified = true;
            dataBaseContext.SaveChanges();
        }

        public void UpdateDescription(Company company)
        {
            dataBaseContext.Entry(company).Property(c => c.Description).IsModified = true;
            dataBaseContext.SaveChanges();
        }
    }
}