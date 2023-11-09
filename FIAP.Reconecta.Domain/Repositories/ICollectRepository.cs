using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRepository : IBaseRepository<Collect>
    {
        IEnumerable<Collect> Get(CollectStatus status);
        IEnumerable<Collect> GetByEstablishmentId(int establishmentId);
        IEnumerable<Collect> GetByEstablishmentId(int establishmentId, CollectStatus status);
        IEnumerable<Collect> GetByOrganizationId(int organizationId);
        IEnumerable<Collect> GetByOrganizationId(int organizationId, CollectStatus status);
    }
}
