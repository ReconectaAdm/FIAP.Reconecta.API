using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Domain.Services
{
    public interface ICollectRatingService : IBaseService<CollectRating>
    {
        IEnumerable<CollectRating> GetByOrganizationId(int organizationId);
        CollectRating GetSummary(int organizationId);
    }
}
