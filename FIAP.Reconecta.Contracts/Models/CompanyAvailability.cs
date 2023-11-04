using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Contracts.Models
{
    [Table("t_disponibilidade_empresa")]
    public class CompanyAvailability
    {
        [Key]
        [Column("disponibilidade_empresa_id")]
        public int Id { get; set; }
        [Column("empresa_id")]
        public int CompanyId { get; set; }
        [Column("dia_inicial")]
        public string? StartDay { get; set; }
        [Column("dia_final")]
        public string? EndDay { get; set; }
        [Column("horario_inicial")]
        public string? StartHour { get; set; }
        [Column("horario_final")]
        public string? EndHour { get; set; }
        public Company? Company { get; set; }
    }
}
