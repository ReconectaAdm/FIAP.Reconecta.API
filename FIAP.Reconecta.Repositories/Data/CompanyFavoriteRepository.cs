using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Reconecta.Repositories.Data
{
    public class CompanyFavoriteRepository : ICompanyFavoriteRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public CompanyFavoriteRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        #region Base

        public IEnumerable<CompanyFavorite> Get()
        {
            return dataBaseContext.CompanyFavorite;
        }

        public CompanyFavorite? GetById(int organizationId)
        {
            return dataBaseContext.CompanyFavorite.AsNoTracking()
                .FirstOrDefault(cf => cf.OrganizationId == organizationId);
        }

        public CompanyFavorite? GetById(int organizationId, int establishmentId)
        {
            return dataBaseContext.CompanyFavorite.AsNoTracking()
                .FirstOrDefault(cf => cf.OrganizationId == organizationId && cf.EstablishmentId == establishmentId);
        }

        public void Add(CompanyFavorite companyFavorite)
        {
            dataBaseContext.CompanyFavorite.Add(companyFavorite);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<CompanyFavorite> companyFavorites)
        {
            dataBaseContext.CompanyFavorite.AddRange(companyFavorites);
            dataBaseContext.SaveChanges();
        }

        public void Update(CompanyFavorite companyFavorite)
        {
            dataBaseContext.CompanyFavorite.Update(companyFavorite);
            dataBaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var companyFavorite = new CompanyFavorite { OrganizationId = id };
            dataBaseContext.CompanyFavorite.Remove(companyFavorite);
            dataBaseContext.SaveChanges();
        }

        #endregion

    }
}