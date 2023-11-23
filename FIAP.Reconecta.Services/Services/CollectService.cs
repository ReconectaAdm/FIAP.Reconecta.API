using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Collect.Summary;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;
using System.Data.Entity.Core;

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

        public GetCollectSummary GetSummary(int companyId)
        {
            var collects = _collectionRepository.GetSummary(companyId);

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

        public GetCollectSummary GetSummary(int companyId, DateTime? initialDate, DateTime? endDate)
        {
            IEnumerable<Collect> collects;

            if (initialDate != null && endDate != null)
                collects = _collectionRepository.GetSummary(companyId, initialDate.Value, endDate.Value);

            else
                collects = _collectionRepository.GetSummary(companyId);


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

        public void UpdateStatus(int id, CollectStatus status, int companyId)
        {
            var collect = _collectionRepository.GetById(id) ?? throw new ObjectNotFoundException("Coleta não encontrada");

            if (collect.OrganizationId != companyId && collect.EstablishmentId != companyId)
                throw new Exception("Não é possível alterar o status de uma coleta não pertencente ao estabelecimento/organização");

            _collectionRepository.UpdateStatus(new Collect { Id = id, Status = status }); ;
        }
    }
}
