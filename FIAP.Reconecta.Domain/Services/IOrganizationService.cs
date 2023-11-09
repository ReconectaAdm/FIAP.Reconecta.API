using FIAP.Reconecta.Contracts.Models.Company;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IOrganizationService : IBaseService<Company>
    {
        IEnumerable<Company> Get(int establishmentId = 0);
    }
}
