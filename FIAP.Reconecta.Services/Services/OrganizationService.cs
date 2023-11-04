using FIAP.Reconecta.Contracts.Models;
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

        public override IEnumerable<Company> Get()
        {
            return _companyRepository.GetOrganizations(5);
        }
    }
}
