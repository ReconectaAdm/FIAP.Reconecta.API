using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Payment
{
    [Table("t_estabelecimento_pagamento")]
    public class EstablishmentPayment
    {
        [Key]
        [Column("estabelecimento_pagamento_id")]
        public int Id { get; set; }

        [Column("estabelecimento_id")]
        public int EstablishmentId { get; set; }

        [Column("banco_id")]
        public string? BankId { get; set; }

        [Column("agencia")]
        public string? Agency { get; set; }

        [Column("conta")]
        public string? Account { get; set; }

        [Column("nome")]
        public string? Name { get; set; }

        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Column("pix")]
        public string? Pix { get; set; }

    }
}
