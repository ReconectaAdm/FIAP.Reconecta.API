using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Company;
using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class EstablishmentController : BaseController
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        #region Base

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            var establishments = _establishmentService.Get();
            return Ok(establishments);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> Get([FromRoute] int id)
        {
            var establishment = _establishmentService.GetById(id);

            if (establishment != null)
                return Ok(establishment);
            else
                return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Company> Post([FromBody] PostCompany dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var establishment = (Company)dto;
            establishment.Type = CompanyType.ESTABLISHMENT;

            _establishmentService.Add(establishment);

            var location = new Uri(Request.GetEncodedUrl() + "/" + establishment.Id);
            return Created(location, dto);
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Put([FromRoute] int id, [FromBody] PutCompany dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var establishment = (Company)dto;
            establishment.Id = id;
            establishment.Type = CompanyType.ESTABLISHMENT;

            _establishmentService.Update(establishment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Company> Delete([FromRoute] int id)
        {
            try
            {
                var establishment = _establishmentService.GetById(id);

                if (establishment != null)
                {
                    _establishmentService.Delete(id);
                    return NoContent();
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        #endregion

        [HttpGet("me")]
        public ActionResult<Company> GetMyProfile()
        {
            var establishment = _establishmentService.GetById(CompanyId);
            if (establishment != null)
                return Ok(establishment);
            else
                return NotFound();
        }

        [HttpGet("logo/{id}")]
        public ActionResult GetLogo([FromRoute] int id)
        {
            var logo = _establishmentService.GetLogo(id);

            if (logo is null)
                return NotFound();

            return File(logo, "image/jpeg");
        }

        [HttpPatch("logo")]
        public ActionResult<Company> PatchLogo([FromForm] IFormFile file)
        {
            _establishmentService.UpdateLogo(CompanyId, file);
            return NoContent();
        }
    }
}
