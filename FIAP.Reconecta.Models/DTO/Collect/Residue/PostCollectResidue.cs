using FIAP.Reconecta.Models.Entities.Collect;

namespace FIAP.Reconecta.Models.DTO.Collect.Residue
{
    public class PostCollectResidue
    {
        public int ResidueId { get; set; }
        public int Quantity { get; set; }

        public static explicit operator CollectResidue(PostCollectResidue dto)
        {
            var residue = new CollectResidue()
            {
                ResidueId = dto.ResidueId,
                Quantity = dto.Quantity
            };

            residue.CalculatePoints();

            return residue;
        }
    }
}
