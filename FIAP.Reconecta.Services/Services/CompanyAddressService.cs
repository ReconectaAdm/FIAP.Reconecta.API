using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Infrastructure.Data.Repositories;

namespace FIAP.Reconecta.Application.Services
{
    public class CompanyAddressService : BaseService<CompanyAddress>, ICompanyAddressService
    {
        public CompanyAddressService(ICompanyAddressRepository companyAddressRepository) : base(companyAddressRepository)
        {
        }
    }
}
