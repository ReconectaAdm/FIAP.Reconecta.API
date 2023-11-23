using FIAP.Reconecta.Models.Entities.Company;
using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Residue
{
    [Table("t_residuo")]
    public class Residue
    {
        [HiddenInput]
        [Key]
        [Column("residuo_id")]
        public int Id { get; set; }

        [Display(Name = "Nome tipo de residuo")]
        [Column("residuo_nome")]
        public string? Name { get; set; }

        [Display(Name = "Unidade de Medida do resíduo")]
        [Column("unidade_medida")]
        public UnitMeasure? UnitMeasure { get; set; }

        [Display(Name = "Valor pago do resíduo pela organização")]
        [Column("valor_pago")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Categoria do resíduo")]
        [Column("tipo_residuo_id")]
        public int TypeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("residuo_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("residuo_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("organizacao_id")]
        public int OrganizationId { get; set; }

        public Company.Company? Organization { get; set; }
        public ResidueType? Type { get; set; }
    }
}
