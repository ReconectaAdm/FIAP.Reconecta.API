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
                .Include(c => c.Addresses)
                .Include(c => c.Residues)
                .Include(c => c.Availability)
                //.Include(c => c.Collects)
                //    .ThenInclude(cl => cl.Residues)
                .FirstOrDefault(c => c.Id == id && c.Type == CompanyType.ORGANIZATION);
        }

        public IEnumerable<Organization> GetByDistanceAndResidueTypeId(double latitude, double longitude, int residueTypeId, int miles = 10000, int establishmentId = 0)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var location = geometryFactory.CreatePoint(new Coordinate(latitude, longitude));

            var organizations = dataBaseContext.Organization.Where(
                    c => c.Type == CompanyType.ORGANIZATION)
                .Include(c => c.Addresses)
                .Include(c => c.Favorites.Where(f => f.EstablishmentId == establishmentId))
                .Include(c => c.Residues)
                .Where(c => c.Residues!.Any(r => r.TypeId == residueTypeId));

            var nearestOrganizations = organizations.Where(c => c.Addresses != null &&
                           c.Addresses.Any(a => a.Geolocalization != null &&
                           a.Geolocalization.IsWithinDistance(location, miles)
                       ));

            return nearestOrganizations;
        }

        public IEnumerable<Organization> GetByResidueTypeId(int residueTypeId, int establishmentId)
        {
            return dataBaseContext.Organization
                .Include(c => c.Addresses)
                .Include(c => c.Favorites.Where(f => f.EstablishmentId == establishmentId))
                .Include(c => c.Residues)
                .Where(c => c.Residues!.Any(r => r.TypeId == residueTypeId));
        }
    }
}
