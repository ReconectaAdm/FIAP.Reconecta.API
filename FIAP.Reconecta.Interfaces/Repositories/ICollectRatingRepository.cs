using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRatingRepository : IBaseRepository<CollectRating>
    {
        CollectRating? GetSummary(int organizationId);
    }
}
