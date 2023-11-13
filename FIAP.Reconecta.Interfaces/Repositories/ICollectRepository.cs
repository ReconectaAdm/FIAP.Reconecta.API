using FIAP.Reconecta.Models.DTO.Collect;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRepository : IBaseRepository<Collect>
    {
        IEnumerable<Collect> Get(CollectStatus status);
        IEnumerable<Collect> GetByEstablishmentId(int establishmentId);
        IEnumerable<Collect> GetByEstablishmentId(int establishmentId, CollectStatus status);
        IEnumerable<Collect> GetByOrganizationId(int organizationId);
        IEnumerable<Collect> GetByOrganizationId(int organizationId, CollectStatus status);
        IEnumerable<Collect> GetSummary();
    }
}
