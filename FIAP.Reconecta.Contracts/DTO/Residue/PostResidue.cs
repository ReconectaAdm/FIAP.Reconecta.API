namespace FIAP.Reconecta.Contracts.DTO.Residue
{
    public class PostResidue
    {
        public string? Name { get; set; }
        public string? UnitOfMeasure { get; set; }
        public int Type { get; set; }

        public static explicit operator Models.Residue.Residue(PostResidue residue)
            => new() { Name = residue.Name, UnitOfMeasure = residue.UnitOfMeasure, Type = residue.Type };
    }
}
