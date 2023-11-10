using FIAP.Reconecta.Contracts.Models.Company;
using Microsoft.AspNetCore.Http;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IEstablishmentService : IBaseService<Company>
    {
        void UpdateLogo(int establishmentId, IFormFile file);
    }
}
