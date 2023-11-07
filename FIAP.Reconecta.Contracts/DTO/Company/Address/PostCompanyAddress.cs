using FIAP.Reconecta.Contracts.Models.Company;

namespace FIAP.Reconecta.Contracts.DTO.Company.Address
{
    public class PostCompanyAddress
    {
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public static explicit operator CompanyAddress(PostCompanyAddress companyAddress)
            => new()
            {
                Street = companyAddress.Street,
                Number = companyAddress.Number,
                City = companyAddress.City,
                State = companyAddress.State,
                PostalCode = companyAddress.PostalCode
            };
    }
}
