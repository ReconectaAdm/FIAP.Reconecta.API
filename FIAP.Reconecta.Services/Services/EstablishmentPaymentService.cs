using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class EstablishmentPaymentService : BaseService<EstablishmentPayment>, IEstablishmentPaymentService
    {
        public EstablishmentPaymentService(IEstablishmentPaymentRepository establishmentPaymentRepository) 
            : base(establishmentPaymentRepository)
        {
        }
    }
}
