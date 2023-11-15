using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Interfaces.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        void UpdateLogo(int companyId, IFormFile file);
        void UpdateDescription(int companyId, string description);
        byte[]? GetLogo(int companyId, CompanyType companyType);
    }
}
