using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Services.Services
{
    public class CompanyFavoriteService : BaseService<CompanyFavorite>, ICompanyFavoriteService
    {
        private readonly ICompanyFavoriteRepository _companyFavoriteRepository;
        public CompanyFavoriteService(ICompanyFavoriteRepository companyFavoriteRepository) : base(companyFavoriteRepository)
        {
            _companyFavoriteRepository = companyFavoriteRepository;
        }

        public override void Update(CompanyFavorite entity)
        {
            var companyFavorite = _companyFavoriteRepository.GetById(entity.OrganizationId, entity.EstablishmentId);

            if (companyFavorite is null)
                base.Add(entity);
            else
                base.Update(entity);
        }

    }
}
