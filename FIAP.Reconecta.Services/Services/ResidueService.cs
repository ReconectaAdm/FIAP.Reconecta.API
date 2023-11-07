using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class ResidueService : BaseService<Residue>, IResidueService
    {
        public ResidueService(IResidueRepository residueRepository) : base(residueRepository)
        {
        }
    }
}
