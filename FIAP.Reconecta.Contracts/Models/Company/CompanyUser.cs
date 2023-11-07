using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Company
{
    public class CompanyUser
    {
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("empresa_id")]
        public int CompanyId { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("usuario_empresa_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("usuario_empresa_data_atualizacao")]
        public DateTime UpdateDate { get; set; }
    }
}
