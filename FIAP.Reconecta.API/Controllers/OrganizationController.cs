using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Company;
using FIAP.Reconecta.Models.DTO.Company.Address;
using FIAP.Reconecta.Models.DTO.Company.Availability;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using FIAP.Reconecta.Services.Services;
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
        public ActionResult GetById([FromRoute] int id)
        {
            var organization = _organizationService.GetById(id);

            if (organization is null)
                return NotFound();

            return Ok(organization);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] PostCompany dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);

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

            if (organization is null)
                return NotFound();

            _organizationService.Delete(id);
            return NoContent();
        }

        #endregion

        [HttpGet("nearest")]
        public ActionResult GetNearestOrganizations([FromQuery] int residueTypeId, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            IEnumerable<Organization> organizations;

            if (CompanyType == CompanyType.ESTABLISHMENT)
                organizations = _organizationService.Get(latitude, longitude, residueTypeId, CompanyId);
            else
                organizations = _organizationService.Get(latitude, longitude, residueTypeId);

            return Ok(organizations);
        }

        [HttpGet("me")]
        public ActionResult GetMyProfile()
        {
            var organization = _organizationService.GetById(CompanyId);

            if (organization is null)
                return NotFound();

            return Ok(organization);
        }

        [HttpGet("logo/{id}")]
        [AllowAnonymous]
        public ActionResult GetLogo([FromRoute] int id, [FromQuery] string token)
        {
            var isValid = TokenService.ValidateToken(token);

            if (!isValid)
                return Unauthorized();

            var logo = _organizationService.GetLogo(id, CompanyType.ORGANIZATION);

            if (logo is null)
                return NotFound();

            return File(logo, "image/jpeg");
        }

        [HttpGet("residueType/{residueTypeId}")]
        public ActionResult GetByResidueTypeId([FromRoute] int residueTypeId)
        {
            var organizations = _organizationService.GetByResidueTypeId(residueTypeId, CompanyId);

            if (organizations is null)
                return NotFound();

            return Ok(organizations);
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

        [HttpPost("address")]
        public ActionResult CreateAddress(List<PostCompanyAddress> dtos)
        {
            var addresses = dtos.Select(dto =>
            {
                dto.CompanyId = CompanyId;
                return (CompanyAddress)dto;
            });

            _companyAddressService.AddRange(addresses);

            return Ok();
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
