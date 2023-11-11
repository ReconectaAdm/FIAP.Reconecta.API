using FIAP.Reconecta.Contracts.Models.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IOrganizationService : IBaseService<Company>
    {
        IEnumerable<Company> Get(int establishmentId = 0);
        IEnumerable<Company> Get(double latitude, double longitude, int establishmentId = 0);
        void UpdateDescription(int organizationId, string description);
        void UpdateLogo(int organizationId, IFormFile file);
    }
}
