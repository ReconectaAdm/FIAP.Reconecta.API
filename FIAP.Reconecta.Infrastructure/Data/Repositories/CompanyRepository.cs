using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Infrastructure.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                .Include(company => company.Residues)
                .Include(company => company.Availability)
                .Include(company => company.Points)
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

        public void UpdateLogo(Company company)
        {
            dataBaseContext.Entry(company).Property(c => c.Logo).IsModified = true;
            dataBaseContext.SaveChanges();
        }

        #region Organization

        public IEnumerable<Company> GetOrganizations(int establishmentId = 0)
        {
            return dataBaseContext.Organization.Where(company => company.Type == CompanyType.ORGANIZATION)
                .Include(company => company.Addresses)
                .Include(company => company.Favorites.Where(f => f.EstablishmentId == establishmentId));
        }

        public IEnumerable<Company> GetNearestOrganizations(double latitude, double longitude, int miles = 10000, int establishmentId = 0)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var location = geometryFactory.CreatePoint(new Coordinate(latitude, longitude));

            var organizations = dataBaseContext.Organization.Where(
                    company => company.Type == CompanyType.ORGANIZATION).Include(company => company.Addresses);

            var list = organizations.Where(company => company.Addresses != null && company.Addresses.Any() &&
                                           company.Addresses.First().Geolocalization != null && 
                                           company.Addresses.First().Geolocalization!.IsWithinDistance(location, miles));
            return list;
                //company.Addresses.Any(
                //    address => address.Geolocalization != null && address.Geolocalization.IsWithinDistance(location, miles)
                // ))
                //.Include(company => company.Addresses)
                //.Include(company => company.Favorites.Where(f => f.EstablishmentId == establishmentId))
                //.OrderBy(c => c.Addresses.FirstOrDefault().Geolocalization.Distance(location));
        }

        public Company? GetOrganizationById(int id)
        {
            return dataBaseContext.Organization.AsNoTracking()
                .Include(company => company.Residues)
                .Include(company => company.Availability)
                .Include(company => company.Points)
                .Include(company => company.Collects)
                    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(o => o.Id == id && o.Type == CompanyType.ORGANIZATION);
        }

        #endregion

        #region Establishment

        public IEnumerable<Company> GetEstablishments()
        {
            return dataBaseContext.Establishment.Where(company => company.Type == CompanyType.ESTABLISHMENT)
                .Include(company => company.Addresses);
        }

        public Company? GetEstablishmentById(int id)
        {
            return dataBaseContext.Establishment.AsNoTracking()
                .Include(company => company.Residues)
                .Include(company => company.Availability)
                .Include(company => company.Points)
                .Include(company => company.Collects)
                    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(e => e.Id == id && e.Type == CompanyType.ESTABLISHMENT);
        }

        #endregion

    }
}