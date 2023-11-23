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
        public string? Phone { get; set; }
        [Required]
        public IEnumerable<PostCompanyAddress> Addresses { get; set; } = Enumerable.Empty<PostCompanyAddress>();
        [Required]
        public PostUser? User { get; set; }

        public static explicit operator Entities.Company.Company(PostCompany dto) => new()
        {
            Cnpj = dto.Cnpj,
            Name = dto.Name,
            CorporateReason = dto.CorporateReason,
            Description = dto.Description,
            Phone = dto.Phone,  
            Addresses = dto.Addresses.Select(address => (CompanyAddress)address).ToArray(),
            User = dto.User is not null ? (Entities.User.User)dto.User : null
        };
    }
}
