using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Collect
{
    [Table("t_avaliacao_coleta")]
    public class CollectRating
    {
        [Key]
        [Column("coleta_id")]
        public int CollectId { get; set; }

        [Column("comentario")]
        public string? Comment { get; set; }

        [Column("pontualidade")]
        public decimal Punctuality { get; set; }

        [Column("satisfacao")]
        public decimal Satisfaction { get; set; }

        public decimal Rating { get => (Punctuality + Satisfaction) / 2; }
        public Collect? Collect { get; set; }
    }
}
