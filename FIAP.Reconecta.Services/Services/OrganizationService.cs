using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Services.Services
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
            var organizations = _companyRepository.GetNearestOrganizations(latitude, longitude, 10000, establishmentId);

            foreach (var organization in organizations)
            {
                foreach (var adress in organization.Addresses)
                    adress.CalculateDistance(latitude, longitude);

                organization.Addresses = organization.Addresses.OrderBy(a => a.Distance).ToArray();
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

        public void UpdateDescription(int organizationId, string description)
        {
            _companyRepository.UpdateDescription(new Company { Id = organizationId, Description = description });
        }
    }
}
