using FIAP.Reconecta.Contracts.Models.Company;

namespace FIAP.Reconecta.Contracts.DTO.Company.Availability
{
    public class PostCompanyAvailability
    {
        public string? StartDay { get; set; }
        public string? EndDay { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }

        public static explicit operator CompanyAvailability(PostCompanyAvailability companyAvailability) => new()
        {
            StartDay = companyAvailability.StartDay,
            EndDay = companyAvailability.EndDay,
            StartHour = companyAvailability.StartHour,
            EndHour = companyAvailability.EndHour
        };
    }
}
