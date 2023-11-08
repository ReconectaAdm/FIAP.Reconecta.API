namespace FIAP.Reconecta.Contracts.DTO.Residue
{
    public class PostResidue
    {
        public string? Nome { get; set; }
        public string? UnidadeMedida { get; set; }
        public int Tipo { get; set; }

        public static explicit operator Models.Residue.Residue(PostResidue residue)
            => new() { Name = residue.Nome, UnitOfMeasure = residue.UnidadeMedida, Type = residue.Tipo };
    }
}
