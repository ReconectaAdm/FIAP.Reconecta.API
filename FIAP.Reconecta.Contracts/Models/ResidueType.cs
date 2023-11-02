using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_tipo_residuo")]
    public class ResidueType
    {
        [Key]
        [Column("tipo_residuo_id")]
        public int Id { get; set; }
        [Column("tipo_residuo_nome")]
        public string? Nome { get; set; }
    }
}
