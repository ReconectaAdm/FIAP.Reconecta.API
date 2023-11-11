using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Payment
{
    [Table("t_organizacao_pagamento")]
    public class OrganizationPayment
    {
        [Key]
        [Column("organizacao_pagamento_id")]
        public int Id { get; set; }

        [Column("organizacao_id")]
        public int OrganizationId { get; set; }

        [Column("numero_cartao")]
        public string? CardNumber { get; set; }

        [Column("vencimento")]
        public string? DueDate { get; set; }

        [Column("cvv")]
        public string? Cvv { get; set; }

        [Column("nome_cartao")]
        public string? CardName { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }
    }
}
