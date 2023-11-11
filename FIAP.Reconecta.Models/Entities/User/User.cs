using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIAP.Reconecta.Models.Entities.User
{
    [Table("t_usuario")]
    public class User
    {
        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        [Column("senha")]
        public string Password { get; set; } = string.Empty;

        [Column("empresa_id")]
        public int CompanyId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("usuario_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("usuario_data_atualizacao")]
        public DateTime? UpdateDate { get; set; }

        public Company.Company? Company { get; set; }
    }
}
