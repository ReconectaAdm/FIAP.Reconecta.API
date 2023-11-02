using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_coleta")]
    public class Collect
    {
        [HiddenInput]
        [Key]
        [Column("coleta_id")]
        public int Id { get; set; }

        [Display(Name = "Data e hora da coleta")]
        [Column("coleta_data")]
        public DateTime Data { get; set; }

        [Column("status_coleta")]
        public int StatusColeta { get; set; }

        [Column("valor_coleta")]
        public decimal ValorColeta { get; set; }

        [Column("coleta_data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("coleta_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        [Column("estabelecimento_id")]
        public int EstabelecimentoId { get; set; }

        [Column("organizacao_id")]
        public int OrganizacaoId { get; set; }

        //public Company? Estabelecimento { get; set; }
        //public Company? Organizacao { get; set; }
        //public IList<Residue>? Residuos { get; set; }
    }
}
