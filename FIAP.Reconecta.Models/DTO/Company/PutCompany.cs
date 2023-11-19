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

        public static explicit operator Entities.Company.Company(PutCompany company) => new()
        {
            Cnpj = company.Cnpj,
            Name = company.Name,
            CorporateReason = company.CorporateReason,
            Description = company.Description,
            Phone = company.Phone,
            Addresses = company.Addresses.Select(address => (CompanyAddress)address).ToArray(),
        };
    }
}
