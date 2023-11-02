using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    public class CompanyUser
    {
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("usuario_empresa_data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("usuario_empresa_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
