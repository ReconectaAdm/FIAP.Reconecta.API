using FIAP.Reconecta.Models.Enums;

namespace FIAP.Reconecta.Models.DTO.Residue
{
    public class PutResidue
    {
        public string? Name { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public int Type { get; set; }

        public static explicit operator Entities.Residue.Residue(PutResidue residue)
            => new() { Name = residue.Name, UnitMeasure = residue.UnitMeasure, TypeId = residue.Type };
    }
}
