using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Collect;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class CollectService : BaseService<Collect>, ICollectService
    {
        private readonly ICollectRepository _collectionRepository;
        public CollectService(ICollectRepository collectionRepository) : base(collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public IEnumerable<Collect> Get(CompanyType companyType, int companyId, CollectStatus? status = null)
        {
            if (status is null)
            {
                if(companyType == CompanyType.ORGANIZATION)
                    return _collectionRepository.GetByOrganizationId(organizationId: companyId);
                
                else
                    return _collectionRepository.GetByEstablishmentId(establishmentId: companyId);
            }

            else
            {
                if (companyType == CompanyType.ORGANIZATION)
                    return _collectionRepository.GetByOrganizationId(organizationId: companyId, status: status.Value);

                else
                    return _collectionRepository.GetByEstablishmentId(establishmentId: companyId, status: status.Value);
            }
        }
    }
}
