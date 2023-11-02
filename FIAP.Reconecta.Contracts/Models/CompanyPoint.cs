using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_ponto_empresa")]
    public class CompanyPoint
    {
        [Key]
        [Column("ponto_empresa_id")]
        public int Id { get; set; }

        [Column("pontos")]
        public int Pontos { get; set; }

        [Column("ponto_empresa_data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("ponto_empresa_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        [Column("empresa_id")]
        public int EmpresaId { get; set; }

        public Company? Empresa { get; set; }
    }
}
