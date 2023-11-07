using FIAP.Reconecta.Contracts.Models.Company;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Collect
{
    [Table("t_coleta")]
    public class Collect
    {
        [HiddenInput]
        [Key]
        [Column("coleta_id")]
        public int Id { get; set; }

        [Display(Name = "Data e hora da coleta")]

        [Column("status_coleta")]
        public int Status { get; set; }

        [Column("coleta_valor")]
        public decimal Value { get; set; }

        [Column("coleta_data_criacao")]
        public DateTime CreationDate { get; set; }

        [Column("coleta_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("estabelecimento_id")]
        public int EstablishmentId { get; set; }

        [Column("organizacao_id")]
        public int OrganizationId { get; set; }

        [Column("coleta_data")]
        public DateTime Date { get; set; }

        [Column("coleta_hora")]
        public string? Hour { get; set; }

        public Establishment? Establishment { get; set; }
        public Organization? Organization { get; set; }
        public ICollection<CollectResidue>? Residues { get; set; }
        public CollectRating? Rating { get; set; }
    }
}
