using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyAvailabilityRepository : IBaseRepository<CompanyAvailability>
    {
        IEnumerable<CompanyAvailability> GetByCompanyId(int companyId);
        void UpdateRange(IEnumerable<CompanyAvailability> companyAvailability);
    }
}
