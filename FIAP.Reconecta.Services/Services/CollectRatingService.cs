using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Services.Services
{
    public class CollectRatingService : BaseService<CollectRating>, ICollectRatingService
    {
        private readonly ICollectRatingRepository _collectionRepository;
        public CollectRatingService(ICollectRatingRepository collectionRepository) : base(collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public IEnumerable<CollectRating> GetByOrganizationId(int organizationId)
        {
            return _collectionRepository.GetByOrganizationId(organizationId);
        }

        public CollectRating GetSummary(int organizationId)
        {
            return _collectionRepository.GetSummary(organizationId) ?? new CollectRating();
        }
    }
}
