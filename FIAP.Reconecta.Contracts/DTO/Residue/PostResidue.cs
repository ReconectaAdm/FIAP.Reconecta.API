namespace FIAP.Reconecta.Contracts.DTO.Residue
{
    public class PostResidue
    {
        public string? Nome { get; set; }
        public string? UnidadeMedida { get; set; }
        public int Tipo { get; set; }

        public static explicit operator Models.Residue.Residue(PostResidue residue)
            => new() { Nome = residue.Nome, UnidadeMedida = residue.UnidadeMedida, Tipo = residue.Tipo };
    }
}
