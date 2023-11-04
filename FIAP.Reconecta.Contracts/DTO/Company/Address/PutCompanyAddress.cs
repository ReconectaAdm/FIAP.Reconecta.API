namespace FIAP.Reconecta.Contracts.DTO.Company.Address
{
    public class PutCompanyAddress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public static explicit operator Models.CompanyAddress(PutCompanyAddress companyAddress)
            => new()
            {
                Id = companyAddress.Id,
                Street = companyAddress.Street,
                Number = companyAddress.Number,
                City = companyAddress.City,
                State = companyAddress.State,
                PostalCode = companyAddress.PostalCode
            };
    }
}
