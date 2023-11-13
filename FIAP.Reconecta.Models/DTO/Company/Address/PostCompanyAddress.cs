﻿using FIAP.Reconecta.Models.Entities.Company;
using NetTopologySuite.Geometries;
using System.Data.Entity.Spatial;

namespace FIAP.Reconecta.Models.DTO.Company.Address
{
    public class PostCompanyAddress
    {
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static explicit operator CompanyAddress(PostCompanyAddress companyAddress) => new()
        {
            Street = companyAddress.Street,
            Number = companyAddress.Number,
            City = companyAddress.City,
            State = companyAddress.State,
            PostalCode = companyAddress.PostalCode,
            Latitude = companyAddress.Latitude,
            Longitude = companyAddress.Longitude,
            Geolocalization = new Point(companyAddress.Latitude, companyAddress.Longitude) { SRID = 4326 }
        };
    }
}