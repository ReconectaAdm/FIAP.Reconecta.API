namespace FIAP.Reconecta.Models.DTO.Residue
{
    public class PostResidue
    {
        public string? Name { get; set; }
        public string? UnitOfMeasure { get; set; }
        public int Type { get; set; }

        public static explicit operator Entities.Residue.Residue(PostResidue residue)
            => new() { Name = residue.Name, UnitOfMeasure = residue.UnitOfMeasure, Type = residue.Type };
    }
}
