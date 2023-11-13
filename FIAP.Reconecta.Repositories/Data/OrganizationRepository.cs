using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using FIAP.Reconecta.Repositories.Context;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using Microsoft.EntityFrameworkCore;
using FIAP.Reconecta.Domain.Repositories;

namespace FIAP.Reconecta.Repositories.Data
{
    public class OrganizationRepository : CompanyRepository, IOrganizationRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public OrganizationRepository(DataBaseContext ctx) : base(ctx)
        {
            dataBaseContext = ctx;
        }

        public IEnumerable<Organization> Get(int establishmentId = 0)
        {
            return dataBaseContext.Organization.Where(c => c.Type == CompanyType.ORGANIZATION)
                .Include(c => c.Addresses)
                .Include(c => c.Favorites.Where(f => f.EstablishmentId == establishmentId));
        }

        public override Organization? GetById(int id)
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

        public IEnumerable<Organization> GetByDistance(double latitude, double longitude, int miles = 10000, int establishmentId = 0)
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
    }
}
