using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICollectRatingService : IBaseService<CollectRating>
    {
        CollectRating GetSummary(int organizationId);
    }
}
