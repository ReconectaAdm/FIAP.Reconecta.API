using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Collect
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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("residuo_coleta_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("residuo_coleta_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("pontos")]
        public int Points { get; set; }

        [Column("residuo_id")]
        public int? ResidueId { get; set; }

        [Column("coleta_id")]
        public int? CollectId { get; set; }

        public Residue.Residue? Residue { get; set; }
        public Collect? Collect { get; set; }
    }
}
