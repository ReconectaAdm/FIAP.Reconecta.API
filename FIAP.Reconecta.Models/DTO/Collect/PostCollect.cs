using FIAP.Reconecta.Models.DTO.Collect.Residue;
using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Models.DTO.Collect
{
    public class PostCollect
    {
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int EstablishmentId { get; set; }
        public int OrganizationId { get; set; }
        public decimal Value { get; set; }
        public string? Hour { get; set; }
        public IEnumerable<PostCollectResidue>? Residues { get; set; }

        public static explicit operator Entities.Collect.Collect(PostCollect collect) => new()
        {
            Date = collect.Date,
            Status = collect.Status,
            EstablishmentId = collect.EstablishmentId,
            OrganizationId = collect.OrganizationId,
            Value = collect.Value,
            Hour = collect.Hour,
            Residues = collect.Residues?.Select(residue => (CollectResidue)residue).ToArray()
        };
    }
}
