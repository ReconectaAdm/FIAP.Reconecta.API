using FIAP.Reconecta.Contracts.DTO.Company.Address;
using FIAP.Reconecta.Contracts.Models;

namespace FIAP.Reconecta.Contracts.DTO.Company
{
    public class PostCompany
    {
        public string? Cnpj { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CorporateReason { get; set; }
        public IEnumerable<PostCompanyAddress>? Enderecos { get; set; }

        public static explicit operator Models.Company(PostCompany company)
            => new()
            {
                Cnpj = company.Cnpj,
                Description = company.Description,
                Name = company.Name,
                CorporateReason = company.CorporateReason,
                Addresses = company.Enderecos?.Select(address => (CompanyAddress)address).ToArray()
            };
    }
}
