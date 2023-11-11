using FIAP.Reconecta.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIAP.Reconecta.Models.Entities.Company
{
    [Table("t_disponibilidade_empresa")]
    public class CompanyAvailability
    {
        [Key]
        [Column("disponibilidade_empresa_id")]
        public int Id { get; set; }
        [Column("empresa_id")]
        public int CompanyId { get; set; }
        [Column("dia")]
        public DayOfWeek Day { get; set; }
        [Column("horario_inicial")]
        public string? StartHour { get; set; }
        [Column("horario_final")]
        public string? EndHour { get; set; }
        [Column("disponivel")]
        public bool Available { get; set; }
        public Company? Company { get; set; }
    }
}
