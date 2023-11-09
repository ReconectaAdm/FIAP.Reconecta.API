using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Infrastructure.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base
        public IEnumerable<Company> Get()
        {
            return dataBaseContext.Company.Include(company => company.Addresses);
        }

        public Company? GetById(int id)
        {
            return dataBaseContext.Company.AsNoTracking()
                .Include(c => c.Residues)
                .Include(c => c.Availability)
                .Include(c => c.Points)
                //.Include(c => c.Collects)
                //    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Company company)
        {
            dataBaseContext.Company.Add(company);
            dataBaseContext.SaveChanges();
        }

        public void Update(Company company)
        {
            dataBaseContext.Company.Update(company);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var company = new Company { Id = id };
            dataBaseContext.Company.Remove(company);
            dataBaseContext.SaveChanges();
        }

        #endregion

        #region Organization

        public IEnumerable<Company> GetOrganizations(int establishmentId = 0)
        {
            return dataBaseContext.Company.Where(company => company.Type == CompanyType.ORGANIZATION)
                .Include(company => company.Addresses)
                .Include(comp => comp.Favorites.Where(f => f.EstablishmentId == establishmentId));
        }

        #endregion

        #region Establishment
        public IEnumerable<Company> GetEstablishments()
        {
            return dataBaseContext.Company.Where(company => company.Type == CompanyType.ESTABLISHMENT)
                .Include(company => company.Addresses);
        }
        #endregion

    }
}