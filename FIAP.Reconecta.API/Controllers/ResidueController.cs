using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Residue;
using FIAP.Reconecta.Models.Entities.Residue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class ResidueController : BaseController
    {
        private readonly IResidueService _residueService;
        private readonly IResidueTypeService _residueTypeService;

        public ResidueController(IResidueService residueService, IResidueTypeService residueTypeService)
        {
            _residueService = residueService;
            _residueTypeService = residueTypeService;
        }

        #region Base

        [HttpGet]
        public ActionResult Get()
        {
            if (CompanyType == Models.Enums.CompanyType.ESTABLISHMENT)
                return Forbid();

            var residues = _residueService.Get(CompanyId);

            return Ok(residues);
        }

        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] int id)
        {
            var residue = _residueService.GetById(id);

            if (residue != null)
                return Ok(residue);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var residue = (Residue)dto;
            residue.OrganizationId = CompanyId;

            _residueService.Add(residue);

            var location = new Uri(Request.GetEncodedUrl() + "/" + residue.Id);
            return Created(location, residue);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] PutResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var residue = (Residue)dto;
            residue.Id = id;
            residue.OrganizationId = CompanyId;

            _residueService.Update(residue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var residue = _residueService.GetById(id);

            if (residue != null)
            {
                _residueService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }

        #endregion

        #region Type

        [HttpGet("type")]
        public ActionResult GetTypes()
        {
            var residueTypes = _residueTypeService.Get();
            return Ok(residueTypes);
        }

        #endregion

        [HttpGet("organization/{organizationId}")]
        public ActionResult GetOrganizationResidues([FromRoute] int organizationId)
        {
            var residue = _residueService.Get(organizationId);

            if (residue != null)
                return Ok(residue);
            else
                return NotFound();
        }
    }
}
