using FIAP.Reconecta.Models.DTO.Company.Address;
using FIAP.Reconecta.Models.DTO.Company.Availability;
using FIAP.Reconecta.Models.Entities.Company;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Models.DTO.Company
{
    public class PutCompany
    {
        [Required]
        public string? Cnpj { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? CorporateReason { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public IEnumerable<PutCompanyAddress> Addresses { get; set; } = Enumerable.Empty<PutCompanyAddress>();

        public static explicit operator Entities.Company.Company(PutCompany dto) => new()
        {
            Cnpj = dto.Cnpj,
            Name = dto.Name,
            CorporateReason = dto.CorporateReason,
            Description = dto.Description,
            Phone = dto.Phone,
            Addresses = dto.Addresses.Select(address => (CompanyAddress)address).ToArray(),
        };
    }
}
