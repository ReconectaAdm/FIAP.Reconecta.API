using FIAP.Reconecta.Contracts.DTO.Collect;
using FIAP.Reconecta.Contracts.Models;
using FIAP.Reconecta.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectController : ControllerBase
    {
        private readonly ICollectService _collectService;

        public CollectController(ICollectService collectService)
        {
            _collectService = collectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Collect>> Get()
        {
            var lista = _collectService.Get();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<Collect> Get([FromRoute] int id)
        {
            var collectionModel = _collectService.GetById(id);

            if (collectionModel != null)
                return Ok(collectionModel);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Collect> Post([FromBody] PostCollect dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Collect)dto;
            _collectService.Add(collect);

            var location = new Uri(Request.GetEncodedUrl() + "/" + collect.Id);
            return Created(location, collect);
        }

        [HttpPut("{id}")]
        public ActionResult<Collect> Put([FromRoute] int id, [FromBody] PutCollect dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Collect)dto;
            collect.Id = id;

            _collectService.Update(collect);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Collect> Delete([FromRoute] int id)
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

