using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class OrganizationService : BaseService<Company>, IOrganizationService
    {
        public OrganizationService(ICompanyRepository companyRepository) : base(companyRepository)
        {

        }
    }
}
