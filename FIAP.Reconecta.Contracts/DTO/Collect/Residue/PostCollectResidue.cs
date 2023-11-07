using FIAP.Reconecta.Contracts.Models.Collect;

namespace FIAP.Reconecta.Contracts.DTO.Collect.Residue
{
    public class PostCollectResidue
    {
        public int ResidueId { get; set; }
        public int Quantity { get; set; }

        public static explicit operator CollectResidue(PostCollectResidue residue)
        {
            return new()
            {
                ResidueId = residue.ResidueId,
                Quantity = residue.Quantity
            };
        }
    }
}
