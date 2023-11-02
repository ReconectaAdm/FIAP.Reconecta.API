using FIAP.Reconecta.Contracts.DTO.Company.Address;
using FIAP.Reconecta.Contracts.Models;

namespace FIAP.Reconecta.Contracts.DTO.Company
{
    public class PostCompany
    {
        public string? Cnpj { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Tipo { get; set; }
        public string? RazaoSocial { get; set; }
        public IEnumerable<PostCompanyAddress>? Enderecos { get; set; }

        public static explicit operator Models.Company(PostCompany company)
            => new()
            {
                Cnpj = company.Cnpj,
                Descricao = company.Descricao,
                Nome = company.Nome,
                Tipo = company.Tipo,
                RazaoSocial = company.RazaoSocial,
                Enderecos = company.Enderecos?.Select(address => (CompanyAddress)address).ToArray()
            };
    }
}
