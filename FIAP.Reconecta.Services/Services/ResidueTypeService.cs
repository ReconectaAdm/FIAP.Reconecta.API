using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class ResidueTypeService : BaseService<ResidueType>, IResidueTypeService
    {
        public ResidueTypeService(IResidueTypeRepository residueTypeRepository) : base(residueTypeRepository)
        {
        }
    }
}
