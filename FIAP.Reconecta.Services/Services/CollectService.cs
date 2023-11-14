using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Collect;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Services.Services
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
                return _collectionRepository.GetByCompanyId(companyId: companyId);

            else
                return _collectionRepository.GetByCompanyId(companyId: companyId, status: status.Value);
        }

        public Collect? GetById(int id, int companyId)
        {
            return _collectionRepository.GetById(id, companyId);
        }

        public GetCollectSummary GetSummary()
        {
            var collects = _collectionRepository.GetSummary();

            var summary = new GetCollectSummary
            {
                Collects = collects.Count(),
                Points = collects.Sum(c => c.Residues.Sum(cr => cr.Points)),
                Value = collects.Sum(c => c.Value)
            };

            summary.GenerateResiduesSummary(collects);
            summary.GenerateStatusSummary(collects);

            return summary;
        }
    }
}
