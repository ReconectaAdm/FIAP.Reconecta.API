using FIAP.Reconecta.Contracts.DTO.Company;
using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            var lista = _organizationService.Get();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get([FromRoute] int id)
        {
            var organizations = _organizationService.GetById(id);

            if (organizations != null)
                return Ok(organizations);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Company> Post([FromBody] PostCompany dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var organization = (Company)dto;
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
    }
}
