using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Company
{
    [Table("t_residuo_empresa")]
    public class CompanyResidue
    {
        [Column("valor_pago")]
        public decimal AmountPaid { get; set; }

        [Column("residuo_empresa_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("residuo_empresa_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("residuo_id")]
        public int ResidueId { get; set; }

        [Column("empresa_id")]
        public int OrganizationId { get; set; }

        public Residue.Residue? Residue { get; set; }
        public Company? Organization { get; set; }
    }
}
