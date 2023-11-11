using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Contracts.DTO.Company
{
    public class PatchCompanyDescription
    {
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
