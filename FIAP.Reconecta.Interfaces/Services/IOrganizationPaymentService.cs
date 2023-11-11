using FIAP.Reconecta.Models.DTO.Payment;
using FIAP.Reconecta.Models.Entities.Payment;

namespace FIAP.Reconecta.Domain.Services
{
    public interface IOrganizationPaymentService : IBaseService<OrganizationPayment>
    {
        IEnumerable<GetOrganizationPayment> Get();
    }
}
