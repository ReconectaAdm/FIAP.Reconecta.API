using FIAP.Reconecta.Contracts.DTO.Company;
using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            var lista = _establishmentService.Get();
            return Ok(lista);
        }


        [HttpGet("{id}")]
        public ActionResult<Company> Get([FromRoute] int id)
        {
            var establishments = _establishmentService.GetById(id);

            if (establishments != null)
                return Ok(establishments);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Company> Post([FromBody] PostCompany dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var establishment = (Company)dto;
            establishment.Type = 2;

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
            establishment.Type = 2;

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
    }
}
