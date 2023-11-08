using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Company
{
    [Table("t_endereco_empresa")]
    public class CompanyAddress
    {
        [Column("endereco_empresa_id")]
        public int Id { get; set; }
        [Column("logradouro")]
        public string? Street { get; set; }
        [Column("numero")]
        public string? Number { get; set; }
        [Column("cidade")]
        public string? City { get; set; }
        [Column("estado")]
        public string? State { get; set; }
        [Column("cep")]
        public string? PostalCode { get; set; }
        [Column("empresa_id")]
        public int CompanyId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("endereco_empresa_data_criacao")]
        public DateTime CreationDate { get; set; }
        [Column("endereco_empresa_data_atualizacao")]
        public DateTime UpdateDate { get; set; }
        public Company? Company { get; set; }
    }
}
