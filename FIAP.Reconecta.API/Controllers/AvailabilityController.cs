using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Company.Availability;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class AvailabilityController : BaseController
    {
        private readonly ICompanyAvailabilityService _companyAvailabilityService;

        public AvailabilityController(ICompanyAvailabilityService companyAvailabilityService)
        {
            _companyAvailabilityService = companyAvailabilityService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var companyAvailability = _companyAvailabilityService.GetByCompanyId(CompanyId);
            return Ok(companyAvailability);
        }

        [HttpGet("organization/{organizationId}")]
        public ActionResult GetByCompanyId(int organizationId)
        {
            var companyAvailability = _companyAvailabilityService.GetByCompanyId(organizationId);
            return Ok(companyAvailability);
        }

        [HttpPost]
        public ActionResult Post(IEnumerable<PostCompanyAvailability> dtos)
        {
            if (CompanyType == CompanyType.ESTABLISHMENT)
                return Forbid();

            var companyAvailability = dtos.Select(dto =>
            {
                var dayAvailability = (CompanyAvailability)dto;
                dayAvailability.CompanyId = CompanyId;

                return dayAvailability;
            });

            _companyAvailabilityService.AddRange(companyAvailability);

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(IEnumerable<PutCompanyAvailability> dtos)
        {
            if (CompanyType == CompanyType.ESTABLISHMENT)
                return Forbid();

            var companyAvailability = dtos.Select(dto =>
            {
                var dayAvailability = (CompanyAvailability)dto;
                dayAvailability.CompanyId = CompanyId;

                return dayAvailability;
            });

            _companyAvailabilityService.UpdateRange(companyAvailability);

            return NoContent();
        }

        [HttpDelete("{companyId}")]
        public ActionResult Delete(int companyId)
        {
            if (CompanyType == CompanyType.ESTABLISHMENT)
                return Forbid();

            _companyAvailabilityService.Delete(companyId);

            return NoContent();
        }

    }
}
