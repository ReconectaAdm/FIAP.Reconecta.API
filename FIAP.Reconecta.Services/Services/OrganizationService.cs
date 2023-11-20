using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Services.Services
{
    public class OrganizationService : CompanyService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository) : base(organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IEnumerable<Organization> Get(int establishmentId = 0)
        {
            var organizations = _organizationRepository.Get(establishmentId);
            return organizations;
        }

        public IEnumerable<Organization> Get(double latitude, double longitude, int residueTypeId, int establishmentId = 0)
        {
            var organizations = _organizationRepository.GetByDistanceAndResidueTypeId(latitude, longitude, residueTypeId, 10000, establishmentId);

            foreach (var organization in organizations)
            {
                foreach (var adress in organization.Addresses)
                    adress.CalculateDistance(latitude, longitude);

                organization.Addresses = organization.Addresses.OrderBy(a => a.Distance).ToArray();
            }

            return organizations;
        }

        public override Organization? GetById(int id)
        {
            return _organizationRepository.GetById(id);
        }

        public IEnumerable<Organization> GetByResidueTypeId(int residueTypeId, int establishmentId = 0)
        {
            return _organizationRepository.GetByResidueTypeId(residueTypeId, establishmentId);
        }
    }
}
