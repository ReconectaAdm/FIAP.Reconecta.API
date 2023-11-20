using FIAP.Reconecta.Interfaces.Services;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IOrganizationService : ICompanyService
    {
        IEnumerable<Organization> Get(int establishmentId = 0);
        IEnumerable<Organization> Get(double latitude, double longitude, int residueTypeId, int establishmentId = 0);
        IEnumerable<Organization> GetByResidueTypeId(int residueTypeId, int establishmentId = 0);
    }
}
