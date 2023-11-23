using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Models.DTO.Company.Availability
{
    public class PutCompanyAvailability
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }
        public bool Available { get; set; }

        public static explicit operator CompanyAvailability(PutCompanyAvailability dto) => new()
        {
            Id = dto.Id,
            Day = dto.Day,
            StartHour = dto.StartHour,
            EndHour = dto.EndHour,
            Available = dto.Available
        };
    }
}
