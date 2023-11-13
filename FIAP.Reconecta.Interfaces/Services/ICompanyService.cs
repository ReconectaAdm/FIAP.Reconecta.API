using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Interfaces.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        byte[]? GetLogo(int organizationId);
        void UpdateLogo(int organizationId, IFormFile file);
        void UpdateDescription(int organizationId, string description);
    }
}
