using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class CollectService : BaseService<Collect>, ICollectService
    {
        private readonly ICollectRepository _collectionRepository;
        public CollectService(ICollectRepository collectionRepository) : base(collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public IEnumerable<Collect> Get(CollectStatus? status = null)
        {
            if (status is null)
                return _collectionRepository.Get();
            else
                return _collectionRepository.Get(status.Value);
        }
    }
}
