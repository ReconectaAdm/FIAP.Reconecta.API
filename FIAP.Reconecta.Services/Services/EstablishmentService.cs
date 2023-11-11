using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Services.Services
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

        public override Company? GetById(int id)
        {
            return _companyRepository.GetEstablishmentById(id);
        }

        public void UpdateLogo(int establishmentId, IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);

            _companyRepository.UpdateLogo(new Company { Id = establishmentId, Logo = stream.ToArray() });
        }
    }
}
