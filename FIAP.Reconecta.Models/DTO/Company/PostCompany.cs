using FIAP.Reconecta.Models.DTO.Company.Address;
using FIAP.Reconecta.Models.DTO.User;
using FIAP.Reconecta.Models.Entities.Company;
using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Models.DTO.Company
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

        public static explicit operator Entities.Company.Company(PostCompany company) => new()
        {
            Cnpj = company.Cnpj,
            Name = company.Name,
            CorporateReason = company.CorporateReason,
            Description = company.Description,
            Addresses = company.Addresses.Select(address => (CompanyAddress)address).ToArray(),
            User = company.User is not null ? (Entities.User.User)company.User : null
        };
    }
}
