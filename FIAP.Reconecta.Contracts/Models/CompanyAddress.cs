using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_endereco_empresa")]
    public class CompanyAddress
    {
        [Column("endereco_empresa_id")]
        public int Id { get; set; }
        [Column("logradouro")]
        public string? Logradouro { get; set; }
        [Column("numero")]
        public string? Numero { get; set; }
        [Column("cidade")]
        public string? Cidade { get; set; }
        [Column("estado")]
        public string? Estado { get; set; }
        [Column("cep")]
        public string? Cep { get; set; }
        [Column("empresa_id")]
        public int EmpresaId { get; set; }
        [Column("endereco_empresa_data_criacao")]
        public DateTime DataCriacao { get; set; }
        [Column("endereco_empresa_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
        public Company? Empresa { get; set; }
    }
}
