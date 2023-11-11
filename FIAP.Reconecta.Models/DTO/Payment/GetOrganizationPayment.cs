using FIAP.Reconecta.Utils.Extensions;

namespace FIAP.Reconecta.Models.DTO.Payment
{
    public class GetOrganizationPayment
    {
        public string? CardKey { get; set; }

        public GetOrganizationPayment(string json)
        {
            CardKey = CryptExtensions.AESEncryptString(json);
        }
    }
}
