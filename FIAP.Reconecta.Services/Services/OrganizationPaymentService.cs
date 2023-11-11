using FIAP.Reconecta.Domain.Repositories;
using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Payment;
using FIAP.Reconecta.Models.Entities.Payment;
using Newtonsoft.Json;

namespace FIAP.Reconecta.Services.Services
{
    public class OrganizationPaymentService : BaseService<OrganizationPayment>, IOrganizationPaymentService
    {
        public OrganizationPaymentService(IOrganizationPaymentRepository organizationPaymentRepository)
            : base(organizationPaymentRepository)
        {
        }

        public new IEnumerable<GetOrganizationPayment> Get()
        {
            var organizationPayments = base.Get();

            foreach (var organizationPayment in organizationPayments)
            {
                organizationPayment.DecryptInfo();
                yield return new GetOrganizationPayment(JsonConvert.SerializeObject(organizationPayment));
            }
        }


    }
}
