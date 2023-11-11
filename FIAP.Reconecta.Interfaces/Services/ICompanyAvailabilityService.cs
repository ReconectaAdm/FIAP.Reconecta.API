using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICompanyAvailabilityService : IBaseService<CompanyAvailability>
    {
        IEnumerable<CompanyAvailability> GetByCompanyId(int companyId);
        void UpdateRange(IEnumerable<CompanyAvailability> companyAvailability);
    }
}
