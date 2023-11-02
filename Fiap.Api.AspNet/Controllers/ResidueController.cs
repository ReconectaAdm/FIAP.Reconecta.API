using FIAP.Reconecta.Contracts.DTO.Residue;
using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidueController : ControllerBase
    {
        private readonly IResidueService _collectService;

        public ResidueController(IResidueService collectService)
        {
            _collectService = collectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Residue>> Get()
        {
            var lista = _collectService.Get();

            if (lista != null)
                return Ok(lista);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Residue> Get([FromRoute] int id)
        {
            var collectionModel = _collectService.GetById(id);

            if (collectionModel != null)
                return Ok(collectionModel);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Residue> Post([FromBody] PostResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Residue)dto;
            _collectService.Add(collect);

            var location = new Uri(Request.GetEncodedUrl() + "/" + collect.Id);
            return Created(location, collect);
        }

        [HttpPut("{id}")]
        public ActionResult<Residue> Put([FromRoute] int id, [FromBody] PutResidue dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Residue)dto;
            collect.Id = id;

            _collectService.Update(collect);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Residue> Delete([FromRoute] int id)
        {
            var collectionModel = _collectService.GetById(id);

            if (collectionModel != null)
            {
                _collectService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
