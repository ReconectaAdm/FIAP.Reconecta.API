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

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        #region Base

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            IEnumerable<Company> organizations;

            if (CompanyType == CompanyType.ESTABLISHMENT)
                organizations = _organizationService.Get(CompanyId);
            else
                organizations = _organizationService.Get();

            return Ok(organizations);
        }

        [HttpGet("nearest")]
        public ActionResult<IEnumerable<Company>> GetNearestOrganizations([FromQuery] double latitude, [FromQuery] double longitude)
        {
            IEnumerable<Company> organizations;

            if (CompanyType == CompanyType.ESTABLISHMENT)
                organizations = _organizationService.Get(latitude, longitude, CompanyId);
            else
                organizations = _organizationService.Get(latitude, longitude);

            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get([FromRoute] int id)
        {
            var organization = _organizationService.GetById(id);

            if (organization != null)
                return Ok(organization);
            else
                return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Company> Post([FromBody] PostCompany dto)
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
        public ActionResult<Company> Put([FromRoute] int id, [FromBody] PutCompany dto)
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
        public ActionResult<Company> Delete([FromRoute] int id)
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

        [HttpGet("me")]
        public ActionResult<Company> GetMyProfile()
        {
            var organization = _organizationService.GetById(CompanyId);

            if (organization != null)
                return Ok(organization);
            else
                return NotFound();
        }

        [HttpPatch("logo")]
        public ActionResult<Company> PatchLogo([FromForm] IFormFile formFile)
        {
            _organizationService.UpdateLogo(CompanyId, formFile);
            return NoContent();
        }
    }
}
