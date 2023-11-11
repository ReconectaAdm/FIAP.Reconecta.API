using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Company? GetEstablishmentById(int id);
        IEnumerable<Company> GetEstablishments();
        IEnumerable<Company> GetNearestOrganizations(double latitude, double longitude, int miles = 2000, int establishmentId = 0);
        Company? GetOrganizationById(int id);
        IEnumerable<Company> GetOrganizations(int establishmentId = 0);
        void UpdateDescription(Company company);
        void UpdateLogo(Company company);
    }
}
