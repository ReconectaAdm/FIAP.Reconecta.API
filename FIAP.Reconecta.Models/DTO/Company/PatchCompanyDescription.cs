using System.ComponentModel.DataAnnotations;

namespace FIAP.Reconecta.Models.DTO.Company
{
    public class PatchCompanyDescription
    {
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
