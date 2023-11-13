using FIAP.Reconecta.Models.DTO.Collect;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICollectService : IBaseService<Collect>
    {
        IEnumerable<Collect> Get(CompanyType companyType, int companyId, CollectStatus? status = null);
        GetCollectSummary GetSummary();
    }
}
