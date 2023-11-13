using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface ICompanyFavoriteRepository : IBaseRepository<CompanyFavorite>
    {
        CompanyFavorite? GetById(int organizationId, int establishmentId);
    }
}
