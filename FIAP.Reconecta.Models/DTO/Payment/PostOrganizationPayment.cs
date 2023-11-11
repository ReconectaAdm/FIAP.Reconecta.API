using FIAP.Reconecta.Models.Entities.Payment;
using FIAP.Reconecta.Utils.Extensions;

namespace FIAP.Reconecta.Models.DTO.Payment
{
    public class PostOrganizationPayment
    {
        public string CardNumber { get; set; } = string.Empty;
        public string DueDate { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string CardName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;

        public static explicit operator OrganizationPayment(PostOrganizationPayment dto) => new()
        {
            CardNumber = CryptExtensions.AESEncryptString(dto.CardNumber),
            DueDate = dto.DueDate,
            Cvv = CryptExtensions.AESEncryptString(dto.Cvv),
            CardName = dto.CardName,
            Cnpj = dto.Cnpj
        };
    }
}
