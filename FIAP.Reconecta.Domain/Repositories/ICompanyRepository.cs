using FIAP.Reconecta.Contracts.Models;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        IEnumerable<Company> GetOrganizations(int establishmentId = 0);
    }
}
