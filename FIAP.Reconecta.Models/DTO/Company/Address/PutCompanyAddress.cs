using FIAP.Reconecta.Models.Entities.Company;
using NetTopologySuite.Geometries;

namespace FIAP.Reconecta.Models.DTO.Company.Address
{
    public class PutCompanyAddress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static explicit operator CompanyAddress(PutCompanyAddress dto) => new()
        {
            Id = dto.Id,
            Street = dto.Street,
            Number = dto.Number,
            City = dto.City,
            State = dto.State,
            PostalCode = dto.PostalCode,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            Geolocalization = new Point(dto.Latitude, dto.Longitude) { SRID = 4326 }
        };
    }
}
