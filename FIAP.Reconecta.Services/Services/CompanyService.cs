using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Interfaces.Services;
using FIAP.Reconecta.Models.Entities.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Services.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public byte[]? GetLogo(int companyId)
        {
            return _companyRepository.GetLogo(companyId);
        }

        public void UpdateLogo(int companyId, IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);

            _companyRepository.UpdateLogo(new Company { Id = companyId, Logo = stream.ToArray() });
        }

        public void UpdateDescription(int companyId, string description)
        {
            _companyRepository.UpdateDescription(new Company { Id = companyId, Description = description });
        }
    }
}
