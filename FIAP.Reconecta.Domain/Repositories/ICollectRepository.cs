using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRepository : IBaseRepository<Collect>
    {
        IEnumerable<Collect> Get(CollectStatus status);
    }
}
