using FIAP.Reconecta.Application.Services;
using FIAP.Reconecta.Contracts.DTO.Company;
using FIAP.Reconecta.Contracts.Enums;
using FIAP.Reconecta.Contracts.Models.Company;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class OrganizationController : BaseController
    {
        private readonly IOrganizationService _organizationService;
        private readonly ICompanyAddressService _companyAddressService;

        public OrganizationController(IOrganizationService organizationService, ICompanyAddressService companyAddressService)
        {
            _organizationService = organizationService;
            _companyAddressService = companyAddressService;
        }

        #region Base

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Company> organizations;

            if (CompanyType == CompanyType.ESTABLISHMENT)
                organizations = _organizationService.Get(CompanyId);
            else
                organizations = _organizationService.Get();

            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var organization = _organizationService.GetById(id);

            if (organization != null)
                return Ok(organization);
            else
                return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] PostCompany dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organization = (Company)dto;
            organization.Type = CompanyType.ORGANIZATION;

            _organizationService.Add(organization);

            var location = new Uri(Request.GetEncodedUrl() + "/" + organization.Id);
            return Created(location, dto);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] PutCompany dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organization = (Company)dto;
            organization.Id = id;
            organization.Type = CompanyType.ORGANIZATION;

            _organizationService.Update(organization);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var organization = _organizationService.GetById(id);

            if (organization != null)
            {
                _organizationService.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        [HttpGet("nearest")]
        public ActionResult GetNearestPayments([FromQuery] double latitude, [FromQuery] double longitude)
        {
            IEnumerable<Company> organizations;

            if (CompanyType == CompanyType.ESTABLISHMENT)
                organizations = _organizationService.Get(latitude, longitude, CompanyId);
            else
                organizations = _organizationService.Get(latitude, longitude);

            return Ok(organizations);
        }

        [HttpGet("me")]
        public ActionResult GetMyProfile()
        {
            var organization = _organizationService.GetById(CompanyId);

            if (organization != null)
                return Ok(organization);
            else
                return NotFound();
        }

        [HttpPatch("logo")]
        public ActionResult PatchLogo([FromForm] IFormFile formFile)
        {
            _organizationService.UpdateLogo(CompanyId, formFile);
            return NoContent();
        }

        [HttpPatch("description")]
        public ActionResult PatchDescription(PatchCompanyDescription dto)
        {
            _organizationService.UpdateDescription(CompanyId, dto.Description);
            return NoContent();
        }

        [HttpDelete("address/{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var companyAddress = _companyAddressService.GetById(id);

            if (companyAddress != null)
            {
                _companyAddressService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
