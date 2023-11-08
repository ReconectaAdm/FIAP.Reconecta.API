using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class CollectRatingService : BaseService<CollectRating>, ICollectRatingService
    {
        private readonly ICollectRatingRepository _collectionRepository;
        public CollectRatingService(ICollectRatingRepository collectionRepository) : base(collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public CollectRating GetSummary(int organizationId)
        {
            return _collectionRepository.GetSummary(organizationId) ?? new CollectRating();
        }
    }
}
