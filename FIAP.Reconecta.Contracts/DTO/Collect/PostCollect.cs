using FIAP.Reconecta.Contracts.Models;

namespace FIAP.Reconecta.Contracts.DTO.Collect
{
    public class PostCollect
    {
        public DateTime Data { get; set; }
        public int StatusColeta { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int EstabelecimentoId { get; set; }
        public int OrganizacaoId { get; set; }
        public decimal ValorColeta { get; set; }

        public static explicit operator Models.Collect(PostCollect collect)
            => new()
            {
                Data = collect.Data,
                StatusColeta = collect.StatusColeta,
                DataCriacao = collect.DataCriacao,
                DataAtualizacao = collect.DataAtualizacao,
                EstabelecimentoId = collect.EstabelecimentoId,
                OrganizacaoId = collect.OrganizacaoId,
                ValorColeta = collect.ValorColeta
            };
    }
}
