using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class EstablishmentService : BaseService<Company>, IEstablishmentService
    {
        private readonly ICompanyRepository _companyRepository;
        public EstablishmentService(ICompanyRepository companyRepository)
            : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public override IEnumerable<Company> Get()
        {
            return _companyRepository.GetEstablishments();
        }
    }
}
