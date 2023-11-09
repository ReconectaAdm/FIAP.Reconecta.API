using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class OrganizationService : BaseService<Company>, IOrganizationService
    {
        private readonly ICompanyRepository _companyRepository;
        public OrganizationService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> Get(int establishmentId = 0)
        {
            return _companyRepository.GetOrganizations(establishmentId);
        }
    }
}
