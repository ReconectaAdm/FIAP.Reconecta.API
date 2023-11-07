using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models.Company
{
    [Table("t_favorito_empresa")]
    public class CompanyFavorite
    {
        [Column("estabelecimento_id")]
        public int EstablishmentId { get; set; }
        [Column("organizacao_id")]
        public int OrganizationId { get; set; }
        [Column("is_favorito")]
        public bool IsFavorite { get; set; }
        public Company? Organization { get; set; }
    }
}
