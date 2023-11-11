using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Services.Services
{
    public class CompanyAddressService : BaseService<CompanyAddress>, ICompanyAddressService
    {
        public CompanyAddressService(ICompanyAddressRepository companyAddressRepository) : base(companyAddressRepository)
        {
        }
    }
}
