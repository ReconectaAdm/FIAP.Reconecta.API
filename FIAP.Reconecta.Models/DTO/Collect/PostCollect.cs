using FIAP.Reconecta.Models.DTO.Collect.Residue;
using FIAP.Reconecta.Models.Entities.Collect;
using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Models.DTO.Collect
{
    public class PostCollect
    {
        public DateTime Date { get; set; }
        public CollectStatus Status { get; set; }
        public int OrganizationId { get; set; }
        public decimal Value { get; set; }
        public string? Hour { get; set; }
        public IEnumerable<PostCollectResidue>? Residues { get; set; }

        public static explicit operator Entities.Collect.Collect(PostCollect dto) => new()
        {
            Date = dto.Date,
            Status = dto.Status,
            OrganizationId = dto.OrganizationId,
            Value = dto.Value,
            Hour = dto.Hour,
            Residues = dto.Residues?.Select(residue => (CollectResidue)residue).ToArray()
        };
    }
}
