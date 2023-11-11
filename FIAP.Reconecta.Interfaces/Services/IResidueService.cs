using FIAP.Reconecta.Models.Entities.Residue;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IResidueService : IBaseService<Residue>
    {
        IEnumerable<Residue> Get(int organizationId = 0);
    }
}
