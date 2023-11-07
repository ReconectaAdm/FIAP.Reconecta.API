using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICollectService : IBaseService<Collect>
    {
        IEnumerable<Collect> Get(CollectStatus? status = null);
    }
}
