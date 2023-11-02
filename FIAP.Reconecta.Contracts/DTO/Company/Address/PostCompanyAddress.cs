namespace FIAP.Reconecta.Contracts.DTO.Company.Address
{
    public class PostCompanyAddress
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }

        public static explicit operator Models.CompanyAddress(PostCompanyAddress companyAddress)
            => new()
            {
                Logradouro = companyAddress.Logradouro,
                Numero = companyAddress.Numero,
                Cidade = companyAddress.Cidade,
                Estado = companyAddress.Estado,
                Cep = companyAddress.Cep,
            };
    }
}
