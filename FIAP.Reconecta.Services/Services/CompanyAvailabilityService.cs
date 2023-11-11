using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Services.Services
{
    public class CompanyAvailabilityService : BaseService<CompanyAvailability>, ICompanyAvailabilityService
    {
        private readonly ICompanyAvailabilityRepository _companyAvailabilityRepository;

        public CompanyAvailabilityService(ICompanyAvailabilityRepository companyAvailabilityRepository) : base(companyAvailabilityRepository)
        {
            _companyAvailabilityRepository = companyAvailabilityRepository;
        }

        public IEnumerable<CompanyAvailability> GetByCompanyId(int companyId)
        {
            return _companyAvailabilityRepository.GetByCompanyId(companyId);
        }

        public void UpdateRange(IEnumerable<CompanyAvailability> companyAvailability)
        {
            _companyAvailabilityRepository.UpdateRange(companyAvailability);
        }
    }
}
