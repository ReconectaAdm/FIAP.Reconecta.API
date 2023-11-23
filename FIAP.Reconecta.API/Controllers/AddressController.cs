using FIAP.Reconecta.Domain.Services;
using FIAP.Reconecta.Models.DTO.Company.Address;
using FIAP.Reconecta.Models.Entities.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Reconecta.API.Controllers
{
    [Authorize]
    public class AddressController : BaseController
    {
        private readonly ICompanyAddressService _companyAddressService;

        public AddressController(ICompanyAddressService companyAddressService)
        {
            _companyAddressService = companyAddressService;
        }

        [HttpPost("company")]
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

        [HttpDelete("company/{id}")]
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
