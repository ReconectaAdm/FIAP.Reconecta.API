using FIAP.Reconecta.Contracts.DTO.Company.Address;
using FIAP.Reconecta.Contracts.DTO.Company.Availability;
using FIAP.Reconecta.Contracts.DTO.User;
using FIAP.Reconecta.Contracts.Models.Company;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Contracts.DTO.Company
{
    public class PostCompany
    {
        [Required]
        public string? Cnpj { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? CorporateReason { get; set; }
        public string? Description { get; set; }
        [Required]
        public IEnumerable<PostCompanyAddress> Addresses { get; set; } = Enumerable.Empty<PostCompanyAddress>();
        [Required]
        public PostUser? User { get; set; }

        public static explicit operator Models.Company.Company(PostCompany company) => new()
        {
            Cnpj = company.Cnpj,
            Name = company.Name,
            CorporateReason = company.CorporateReason,
            Description = company.Description,
            Addresses = company.Addresses.Select(address => (CompanyAddress)address).ToArray(),
            User = company.User is not null ? (Models.User.User)company.User : null
        };
    }
}
