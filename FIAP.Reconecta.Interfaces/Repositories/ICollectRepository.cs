using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRepository : IBaseRepository<Collect>
    {
        IEnumerable<Collect> Get(CollectStatus status);
        IEnumerable<Collect> GetByCompanyId(int companyId);
        IEnumerable<Collect> GetByCompanyId(int companyId, CollectStatus status);
        Collect? GetById(int id, int companyId);
        IEnumerable<Collect> GetSummary(int companyId);
        void UpdateStatus(Collect collect);
    }
}
