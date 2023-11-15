using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Interfaces.Services;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
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

        public byte[]? GetLogo(int id, CompanyType companyType)
        {
            return _companyRepository.GetLogo(id, companyType);
        }

        public void UpdateLogo(int id, IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);

            _companyRepository.UpdateLogo(new Company { Id = id, Logo = stream.ToArray() });
        }

        public void UpdateDescription(int id, string description)
        {
            _companyRepository.UpdateDescription(new Company { Id = id, Description = description });
        }
    }
}
