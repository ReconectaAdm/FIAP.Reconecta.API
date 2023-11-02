using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_residuo_collection")]
    public class ResidueCollect
    {
        [HiddenInput]
        [Key]
        [Column("residuo_collection_id")]
        public int? Id { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("empresa_data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("empresa_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        [Column("residuo_id")]
        public int? ResiduoId { get; set; }

        [Column("collection_id")]
        public int? ColetaId { get; set; }

        public Residue? Residuo { get; set; }
        public Collect? Coleta { get; set; }
    }
}
