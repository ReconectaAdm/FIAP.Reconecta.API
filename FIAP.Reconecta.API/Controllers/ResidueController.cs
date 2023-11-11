using FIAP.Reconecta.Contracts.DTO.Residue;
using FIAP.Reconecta.Contracts.Models.Residue;
using FIAP.Reconecta.Domain.Services;
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
        public ActionResult<IEnumerable<Residue>> Get()
        {
            if (CompanyType == Contracts.Enums.CompanyType.ESTABLISHMENT)
                return Forbid();

            var residues = _residueService.Get(CompanyId);

            return Ok(residues);
        }

        [HttpGet("{id}")]
        public ActionResult<Residue> Get([FromRoute] int id)
        {
            var residue = _residueService.GetById(id);

            if (residue != null)
                return Ok(residue);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Residue> Post([FromBody] PostResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var residue = (Residue)dto;
            _residueService.Add(residue);

            var location = new Uri(Request.GetEncodedUrl() + "/" + residue.Id);
            return Created(location, residue);
        }

        [HttpPut("{id}")]
        public ActionResult<Residue> Put([FromRoute] int id, [FromBody] PutResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var residue = (Residue)dto;
            residue.Id = id;

            _residueService.Update(residue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Residue> Delete([FromRoute] int id)
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
        public ActionResult<ResidueType> GetTypes()
        {
            var residueTypes = _residueTypeService.Get();
            return Ok(residueTypes);
        }

        #endregion
    }
}
