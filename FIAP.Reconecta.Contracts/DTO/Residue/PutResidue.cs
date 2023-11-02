namespace FIAP.Reconecta.Contracts.DTO.Residue
{
    public class PutResidue
    {
        public string? Nome { get; set; }
        public string? UnidadeMedida { get; set; }
        public int Tipo { get; set; }

        public static explicit operator Models.Residue(PutResidue residue)
            => new() { Nome = residue.Nome, UnidadeMedida = residue.UnidadeMedida, Tipo = residue.Tipo };
    }
}
