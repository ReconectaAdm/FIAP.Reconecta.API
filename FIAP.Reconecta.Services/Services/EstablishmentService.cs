using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class EstablishmentService : BaseService<Company>, IEstablishmentService
    {
        public EstablishmentService(ICompanyRepository companyRepository)
            : base(companyRepository)
        {
        }
    }
}
