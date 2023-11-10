using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Http;

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
            var organizations = _companyRepository.GetOrganizations(establishmentId);
            return organizations;
        }

        public IEnumerable<Company> Get(double latitude, double longitude, int establishmentId = 0)
        {
            var organizations = _companyRepository.GetNearestOrganizations(latitude, longitude, 2000, establishmentId);

            foreach (var organization in organizations)
            {
                foreach (var adress in organization.Addresses)
                    adress.CalculateDistance(latitude, longitude);
            }

            return organizations;
        }

        public override Company? GetById(int id)
        {
            return _companyRepository.GetOrganizationById(id);
        }

        public void UpdateLogo(int organizationId, IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);

            _companyRepository.UpdateLogo(new Company { Id = organizationId, Logo = stream.ToArray() });
        }
    }
}
