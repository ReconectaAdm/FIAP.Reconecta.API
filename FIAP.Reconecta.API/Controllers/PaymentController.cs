using FIAP.Reconecta.Contracts.DTO.Payment;
using FIAP.Reconecta.Contracts.Models.Payment;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly IOrganizationPaymentService _organizationPaymentService;
        private readonly IEstablishmentPaymentService _establishmentPaymentService;

        public PaymentController(IOrganizationPaymentService paymentService, IEstablishmentPaymentService establishmentPaymentService)
        {
            _organizationPaymentService = paymentService;
            _establishmentPaymentService = establishmentPaymentService;
        }

        #region Organization

        [HttpGet("organization")]
        public ActionResult GetOrganizationPayments()
        {
            if (CompanyType == Contracts.Enums.CompanyType.ESTABLISHMENT)
                return Forbid();

            var payments = _organizationPaymentService.Get();

            return Ok(payments);
        }

        [HttpPost("organization")]
        public ActionResult Post([FromBody] PostOrganizationPayment dto)
        {
            if (CompanyType == Contracts.Enums.CompanyType.ESTABLISHMENT)
                return Forbid();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payment = (OrganizationPayment)dto;
            payment.OrganizationId = CompanyId;
            _organizationPaymentService.Add(payment);

            var location = new Uri(Request.GetEncodedUrl() + "/" + payment.Id);
            return Created(location, payment);
        }

        [HttpDelete("organization/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            if (CompanyType == Contracts.Enums.CompanyType.ESTABLISHMENT)
                return Forbid();

            var payment = _organizationPaymentService.GetById(id);

            if (payment != null)
            {
                _organizationPaymentService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }

        #endregion

        #region Establishment

        [HttpGet("establishment")]
        public ActionResult GetEstablishmentPayments()
        {
            if (CompanyType == Contracts.Enums.CompanyType.ORGANIZATION)
                return Forbid();

            var payments = _establishmentPaymentService.Get();

            return Ok(payments);
        }


        [HttpPost("establishment")]
        public ActionResult PostEstablishmentPayment([FromBody] PostEstablishmentPayment dto)
        {
            if (CompanyType == Contracts.Enums.CompanyType.ORGANIZATION)
                return Forbid();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payment = (EstablishmentPayment)dto;
            payment.EstablishmentId = CompanyId;
            _establishmentPaymentService.Add(payment);

            var location = new Uri(Request.GetEncodedUrl() + "/" + payment.Id);
            return Created(location, payment);
        }

        [HttpDelete("establishment/{id}")]
        public ActionResult DeleteEstablishmentPayment([FromRoute] int id)
        {
            if (CompanyType == Contracts.Enums.CompanyType.ORGANIZATION)
                return Forbid();

            var payment = _establishmentPaymentService.GetById(id);

            if (payment != null)
            {
                _establishmentPaymentService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }

        #endregion
    }
}
