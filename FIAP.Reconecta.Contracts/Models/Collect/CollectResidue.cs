using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Collect
{
    [Table("t_residuo_coleta")]
    public class CollectResidue
    {
        [HiddenInput]
        [Key]
        [Column("residuo_coleta_id")]
        public int? Id { get; set; }

        [Column("quantidade")]
        public int Quantity { get; set; }

        [Column("residuo_coleta_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("residuo_coleta_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("residuo_id")]
        public int? ResidueId { get; set; }

        [Column("coleta_id")]
        public int? CollectId { get; set; }

        public Residue.Residue? Residue { get; set; }
        public Collect? Collect { get; set; }
    }
}
