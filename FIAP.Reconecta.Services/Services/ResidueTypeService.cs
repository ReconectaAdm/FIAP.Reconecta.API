using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Residue;

namespace FIAP.Reconecta.Services.Services
{
    public class ResidueTypeService : BaseService<ResidueType>, IResidueTypeService
    {
        public ResidueTypeService(IResidueTypeRepository residueTypeRepository) : base(residueTypeRepository)
        {
        }
    }
}
