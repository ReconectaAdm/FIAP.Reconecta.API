using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class CollectRatingService : BaseService<CollectRating>, ICollectRatingService
    {
        public CollectRatingService(ICollectRatingRepository collectionRepository) : base(collectionRepository)
        {
        }
    }
}
