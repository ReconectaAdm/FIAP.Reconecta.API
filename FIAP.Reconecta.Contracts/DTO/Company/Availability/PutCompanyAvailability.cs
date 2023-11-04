using FIAP.Reconecta.Contracts.Models;

namespace FIAP.Reconecta.Contracts.DTO.Company.Availability
{
    public class PutCompanyAvailability
    {
        public int Id { get; set; }
        public string? StartDay { get; set; }
        public string? EndDay { get; set; }
        public string? StartHour { get; set; }
        public string? EndHour { get; set; }

        public static explicit operator CompanyAvailability(PutCompanyAvailability companyAvailability)
        {
            return new()
            {
                Id = companyAvailability.Id,
                StartDay = companyAvailability.StartDay,
                EndDay = companyAvailability.EndDay,
                StartHour = companyAvailability.StartHour,
                EndHour = companyAvailability.EndHour
            };
        }
    }
}
