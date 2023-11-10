using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FIAP.Reconecta.Contracts.Models.Company
{
    [Table("t_endereco_empresa")]
    public class CompanyAddress
    {
        [Column("endereco_empresa_id")]
        public int Id { get; set; }
        
        [Column("logradouro")]
        public string? Street { get; set; }
        
        [Column("numero")]
        public string? Number { get; set; }
        
        [Column("cidade")]
        public string? City { get; set; }
        
        [Column("estado")]
        public string? State { get; set; }
        
        [Column("cep")]
        public string? PostalCode { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        [Column("geolocalizacao")]
        [JsonIgnore]
        public Point? Geolocalization { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("endereco_empresa_data_criacao")]
        public DateTime CreationDate { get; set; }
        
        [Column("endereco_empresa_data_atualizacao")]
        public DateTime UpdateDate { get; set; }

        [Column("empresa_id")]
        public int CompanyId { get; set; }

        [NotMapped]
        public double Distance { get; set; }
        public Company? Company { get; set; }

        public void CalculateDistance(double originLat, double originLong)
        {
            double R = 6371e3; 

            double sLat1 = Math.Sin(Radians(originLat));
            double sLat2 = Math.Sin(Radians(Latitude));
            double cLat1 = Math.Cos(Radians(originLat));
            double cLat2 = Math.Cos(Radians(Latitude));
            double cLon = Math.Cos(Radians(originLong) - Radians(Longitude));

            double cosD = sLat1 * sLat2 + cLat1 * cLat2 * cLon;

            double d = Math.Acos(cosD);

            Distance = R * d;
        }

        public static double Radians(double x)
        {
            return x * Math.PI / 180;
        }
    }
}
