using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICollectRatingRepository : IBaseRepository<CollectRating>
    {
        IEnumerable<CollectRating> GetByOrganizationId(int organizationId);
        CollectRating? GetSummary(int organizationId);
    }
}
