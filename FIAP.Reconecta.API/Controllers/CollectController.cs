using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Collect;
using FIAP.Reconecta.Models.DTO.Collect.Rating;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class CollectController : BaseController
    {
        private readonly ICollectService _collectService;
        private readonly ICollectRatingService _collectRatingService;

        public CollectController(ICollectService collectService, ICollectRatingService collectRatingService)
        {
            _collectService = collectService;
            _collectRatingService = collectRatingService;
        }

        #region Base

        [HttpGet]
        public ActionResult Get([FromQuery] CollectStatus? status = null)
        {
            var collects = _collectService.Get(CompanyType, CompanyId, status);
            return Ok(collects);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var collect = _collectService.GetById(id, CompanyId);

            if (collect != null)
                return Ok(collect);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] PostCollect dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Collect)dto;
            collect.EstablishmentId = CompanyId;

            _collectService.Add(collect);

            var location = new Uri(Request.GetEncodedUrl() + "/" + collect.Id);
            return Created(location, collect);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] PutCollect dto)
        {
            if (CompanyType == CompanyType.ORGANIZATION)
                throw new Exception("Não é possível uma organização atualizar os dados da coleta.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var collect = (Collect)dto;
            collect.Id = id;
            collect.EstablishmentId = CompanyId;

            _collectService.Update(collect);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var collect = _collectService.GetById(id);

            if (collect != null)
            {
                _collectService.Delete(id);
                return NoContent();
            }
            else
                return NotFound();
        }

        #endregion

        #region Rating

        [HttpGet("rating/{organizationId}")]
        public ActionResult GetRatings(int organizationId)
        {
            var ratings = _collectRatingService.GetByOrganizationId(organizationId);
            return Ok(ratings);
        }

        [HttpGet("rating/summary")]
        public ActionResult GetRatingSummary()
        {
            if (CompanyType == CompanyType.ESTABLISHMENT)
                throw new Exception("Não é possível gerar sumarização de avaliações para empresas do tipo estabelecimento.");

            var ratings = _collectRatingService.GetSummary(CompanyId);
            return Ok(ratings);
        }

        [HttpPost("rating")]
        public ActionResult PostRating(PostCollectRating dto)
        {
            var collectRating = (CollectRating)dto;
            _collectRatingService.Add(collectRating);

            var location = new Uri(Request.GetEncodedUrl() + "/" + collectRating.CollectId);
            return Created(location, collectRating);
        }

        #endregion

        [HttpGet("summary")]
        public ActionResult GetSummary()
        {
            var summary = _collectService.GetSummary();
            return Ok(summary);
        }
    }
}

