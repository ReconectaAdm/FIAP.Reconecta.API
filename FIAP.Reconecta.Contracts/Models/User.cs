using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_usuario")]
    public class User
    {
        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("usuario_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("usuario_data_atualizacao")]
        public DateTime UpdateDate { get; set; }
    }
}
