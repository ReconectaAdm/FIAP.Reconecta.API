using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        void UpdateLogo(Company company);
        void UpdateDescription(Company company);
        byte[]? GetLogo(int companyId, CompanyType companyType);
    }
}
