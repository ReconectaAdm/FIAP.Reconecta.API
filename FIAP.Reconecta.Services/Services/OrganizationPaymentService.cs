using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;

namespace FIAP.Reconecta.Application.Services
{
    public class OrganizationPaymentService : BaseService<OrganizationPayment>, IOrganizationPaymentService
    {
        public OrganizationPaymentService(IOrganizationPaymentRepository organizationPaymentRepository)
            : base(organizationPaymentRepository)
        {
        }
    }
}
