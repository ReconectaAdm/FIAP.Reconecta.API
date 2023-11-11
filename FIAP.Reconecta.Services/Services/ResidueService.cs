using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class ResidueService : BaseService<Residue>, IResidueService
    {
        private readonly IResidueRepository _residueRepository;

        public ResidueService(IResidueRepository residueRepository) : base(residueRepository)
        {
            _residueRepository = residueRepository;
        }

        public IEnumerable<Residue> Get(int organizationId = 0)
        {
            return _residueRepository.Get(organizationId);
        }
    }
}
