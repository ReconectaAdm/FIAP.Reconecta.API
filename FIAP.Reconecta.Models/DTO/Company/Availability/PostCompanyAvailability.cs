using FIAP.Reconecta.Models.Entities.Company;

namespace FIAP.Reconecta.Models.DTO.Company.Availability
{
    public class PostCompanyAvailability
    {
        public DayOfWeek Day { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }
        public bool Available { get; set; }

        public static explicit operator CompanyAvailability(PostCompanyAvailability companyAvailability) => new()
        {
            Day = companyAvailability.Day,
            StartHour = companyAvailability.StartHour,
            EndHour = companyAvailability.EndHour,
            Available = companyAvailability.Available
        };
    }
}
