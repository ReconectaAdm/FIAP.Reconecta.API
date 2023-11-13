using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        byte[]? GetLogo(int companyId);
        void UpdateLogo(Company company);
        void UpdateDescription(Company company);
    }
}
