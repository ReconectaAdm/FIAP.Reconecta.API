using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Models.Enums;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

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

        public IEnumerable<Company> Get()
        {
            return dataBaseContext.Company.Include(c => c.Addresses);
        }

        public Company? GetById(int id)
        {
            return dataBaseContext.Company.AsNoTracking()
                .Include(c => c.Residues)
                .Include(c => c.Availability)
                .Include(c => c.Points)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Add(Company company)
        {
            dataBaseContext.Company.Add(company);
            dataBaseContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Company> companies)
        {
            dataBaseContext.Company.AddRange(companies);
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

        public void UpdateDescription(Company company)
        {
            dataBaseContext.Entry(company).Property(c => c.Description).IsModified = true;
            dataBaseContext.SaveChanges();
        }

        #region Organization

        public IEnumerable<Company> GetOrganizations(int establishmentId = 0)
        {
            return dataBaseContext.Organization.Where(c => c.Type == CompanyType.ORGANIZATION)
                .Include(c => c.Addresses)
                .Include(c => c.Favorites.Where(f => f.EstablishmentId == establishmentId));
        }

        public IEnumerable<Company> GetNearestOrganizations(double latitude, double longitude, int miles = 10000, int establishmentId = 0)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var location = geometryFactory.CreatePoint(new Coordinate(latitude, longitude));

            var organizations = dataBaseContext.Organization.Where(
                    company => company.Type == CompanyType.ORGANIZATION)
                .Include(c => c.Addresses)
                .Include(c => c.Favorites.Where(f => f.EstablishmentId == establishmentId));

            var nearestOrganizations = organizations.Where(c => c.Addresses != null &&
                           c.Addresses.Any(a => a.Geolocalization != null &&
                           a.Geolocalization.IsWithinDistance(location, miles)
                       ));

            return nearestOrganizations;
        }

        public Company? GetOrganizationById(int id)
        {
            return dataBaseContext.Organization.AsNoTracking()
                .Include(company => company.Addresses)
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
                .Include(company => company.Points)
                .Include(company => company.Collects)
                    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(e => e.Id == id && e.Type == CompanyType.ESTABLISHMENT);
        }

        #endregion

    }
}