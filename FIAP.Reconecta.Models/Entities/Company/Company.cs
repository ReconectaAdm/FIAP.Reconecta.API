using FIAP.Reconecta.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIAP.Reconecta.Models.Entities.Company
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
        public string? Name { get; set; }

        [Display(Name = "Descrição")]
        [Column("empresa_descricao")]
        public string? Description { get; set; }

        [Display(Name = "Tipo de empresa")]
        [Column("empresa_tipo")]
        public CompanyType Type { get; set; }

        [Column("razao_social")]
        public string? CorporateReason { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("empresa_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("empresa_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [JsonIgnore]
        [Column("logo")]
        public virtual byte[]? Logo { get; set; }

        public User.User? User { get; set; }
        public CompanyAvailability? Availability { get; set; }
        public ICollection<Residue.Residue>? Residues { get; set; }

        [JsonIgnore]
        public ICollection<CompanyFavorite> Favorites { get; set; } = new List<CompanyFavorite>();
        public ICollection<CompanyAddress> Addresses { get; set; } = new List<CompanyAddress>();
        public ICollection<CompanyPoint>? Points { get; set; }
        public ICollection<Collect.Collect> Collects { get; set; } = new List<Collect.Collect>();
    }
}
