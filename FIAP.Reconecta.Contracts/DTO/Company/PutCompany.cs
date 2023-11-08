using FIAP.Reconecta.Contracts.DTO.Company.Address;
using FIAP.Reconecta.Contracts.DTO.Company.Availability;
using FIAP.Reconecta.Contracts.Models.Company;

namespace FIAP.Reconecta.Contracts.DTO.Company
{
    public class PutCompany
    {
        public string? Cnpj { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CorporateReason { get; set; }
        public IEnumerable<PutCompanyAddress>? Addresses { get; set; }
        public PutCompanyAvailability? Availability { get; set; }

        public static explicit operator Models.Company.Company(PutCompany company) => new()
        {
            Cnpj = company.Cnpj,
            Description = company.Description,
            Name = company.Name,
            CorporateReason = company.CorporateReason,
            Addresses = company.Addresses?.Select(address => (CompanyAddress)address).ToArray(),
            Availability = company.Availability is not null ? (CompanyAvailability)company.Availability : null
        };
    }
}
