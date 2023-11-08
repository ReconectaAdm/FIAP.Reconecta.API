using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRatingRepository : IBaseRepository<CollectRating>
    {
        CollectRating? GetSummary(int organizationId);
    }
}
