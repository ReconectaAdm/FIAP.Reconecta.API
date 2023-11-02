using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class CollectService : BaseService<Collect>, ICollectService
    {
        public CollectService(ICollectRepository collectionRepository) : base(collectionRepository)
        {
        }
    }
}
