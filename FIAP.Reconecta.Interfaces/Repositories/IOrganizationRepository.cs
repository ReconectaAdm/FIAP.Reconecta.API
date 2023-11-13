using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface IOrganizationRepository : ICompanyRepository
    {
        IEnumerable<Organization> Get(int establishmentId = 0);
        IEnumerable<Organization> GetByDistance(double latitude, double longitude, int miles = 10000, int establishmentId = 0);
        new Organization? GetById(int id);
    }
}
