using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Company;
using FIAP.Reconecta.Models.DTO.Company.Availability;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
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
        private readonly ICompanyFavoriteService _companyFavoriteService;

        public OrganizationController(IOrganizationService organizationService, ICompanyAddressService companyAddressService, ICompanyFavoriteService companyFavoriteService)
        {
            _organizationService = organizationService;
            _companyAddressService = companyAddressService;
            _companyFavoriteService = companyFavoriteService;
        }

        #region Base

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Organization> organizations;

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
        public ActionResult GetNearestOrganizations([FromQuery] double latitude, [FromQuery] double longitude)
        {
            IEnumerable<Organization> organizations;

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

        [HttpGet("logo/{id}")]
        public ActionResult GetLogo([FromRoute] int id)
        {
            var logo = _organizationService.GetLogo(id, CompanyType.ORGANIZATION);

            if (logo is null)
                return NotFound();

            return File(logo, "image/jpeg");
        }

        [HttpPatch("logo")]
        public ActionResult PatchLogo([FromForm] IFormFile file)
        {
            _organizationService.UpdateLogo(CompanyId, file);
            return NoContent();
        }

        [HttpPatch("description")]
        public ActionResult PatchDescription(PatchCompanyDescription dto)
        {
            _organizationService.UpdateDescription(CompanyId, dto.Description);
            return NoContent();
        }

        [HttpPatch("favorite/{organizationId}/{isFavorite}")]
        public ActionResult UpdateFavorite(int organizationId, bool isFavorite)
        {
            if (CompanyType == CompanyType.ORGANIZATION)
                throw new Exception("Não é permitido que uma organização favorite outra.");

            _companyFavoriteService.Update(new CompanyFavorite
            {
                OrganizationId = organizationId,
                IsFavorite = isFavorite,
                EstablishmentId = CompanyId
            });

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
