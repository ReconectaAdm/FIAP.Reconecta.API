using FIAP.Reconecta.Contracts.Models.Payment;

namespace FIAP.Reconecta.Contracts.DTO.Payment
{
    public class PutEstablishmentPayment
    {
        public string? BankId { get; set; }
        public string? Agency { get; set; }
        public string? Account { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public string? Pix { get; set; }

        public static explicit operator EstablishmentPayment(PutEstablishmentPayment dto) => new()
        {
            BankId = dto.BankId,
            Agency = dto.Agency,
            Account = dto.Account,
            Name = dto.Name,
            Cnpj = dto.Cnpj,
            Pix = dto.Pix
        };
    }
}
