using FIAP.Reconecta.Models.Entities.Payment;

namespace FIAP.Reconecta.Models.DTO.Payment
{
    public class PutOrganizationPayment
    {
        public string? CardNumber { get; set; }
        public string? DueDate { get; set; }
        public string? Cvv { get; set; }
        public string? CardName { get; set; }
        public string? Cnpj { get; set; }

        public static explicit operator OrganizationPayment(PutOrganizationPayment dto) => new()
        {
            CardNumber = dto.CardNumber,
            DueDate = dto.DueDate,
            Cvv = dto.Cvv,
            CardName = dto.CardName,
            Cnpj = dto.Cnpj
        };
    }
}
