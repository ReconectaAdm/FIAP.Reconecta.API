using FIAP.Reconecta.Models.Entities.Residue;

namespace FIAP.Reconecta.Domain.Repositories
{
    public interface IResidueRepository : IBaseRepository<Residue>
    {
        IEnumerable<Residue> Get(int organizationId);
    }
}
