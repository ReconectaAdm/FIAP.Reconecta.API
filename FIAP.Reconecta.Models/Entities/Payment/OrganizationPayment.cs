using FIAP.Reconecta.Utils.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Payment
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
        public string CardNumber { get; set; } = string.Empty;

        [Column("vencimento")]
        public string DueDate { get; set; } = string.Empty;

        [Column("cvv")]
        public string Cvv { get; set; } = string.Empty;

        [Column("nome_cartao")]
        public string CardName { get; set; } = string.Empty;

        [Column("cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        public void DecryptInfo()
        {
            CardNumber = CryptExtensions.AESDecryptString(CardNumber);
            Cvv = CryptExtensions.AESDecryptString(Cvv);
        }
    }
}
