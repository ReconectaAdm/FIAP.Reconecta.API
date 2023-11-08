using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICollectRatingService : IBaseService<CollectRating>
    {
        CollectRating GetSummary(int organizationId);
    }
}
