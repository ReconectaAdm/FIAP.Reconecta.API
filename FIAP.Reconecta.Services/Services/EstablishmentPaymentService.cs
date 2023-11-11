using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.Entities.Payment;

namespace FIAP.Reconecta.Services.Services
{
    public class EstablishmentPaymentService : BaseService<EstablishmentPayment>, IEstablishmentPaymentService
    {
        public EstablishmentPaymentService(IEstablishmentPaymentRepository establishmentPaymentRepository)
            : base(establishmentPaymentRepository)
        {
        }
    }
}
