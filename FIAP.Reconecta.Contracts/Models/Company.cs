using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_empresa")]
    public class Company
    {
        [HiddenInput]
        [Key]
        [Column("empresa_id")]
        public int Id { get; set; }

        [Display(Name = "CNPJ")]
        [Column("cnpj")]
        public string? Cnpj { get; set; }

        [Display(Name = "Nome da Empresa")]
        [Column("empresa_nome")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição")]
        [Column("empresa_descricao")]
        public string? Descricao { get; set; }

        [Display(Name = "Tipo de empresa")]
        [Column("empresa_tipo")]
        public string? Tipo { get; set; }

        //[Column("razao_social")]
        //public string? CorporateReason { get; set; }

        [Column("razao_social")]
        public string? RazaoSocial { get; set; }

        [Column("empresa_data_criacao")]
        public DateTime DataCriacao { get; set; }
        [Column("empresa_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        public ICollection<CompanyAddress>? Enderecos { get; set; }
        //public IEnumerable<Collection>? collections { get; set; }
        //public IEnumerable<Residue>? Residuos { get; set; }
    }
}
