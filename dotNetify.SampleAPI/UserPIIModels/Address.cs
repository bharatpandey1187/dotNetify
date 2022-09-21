using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class Address
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UserAddressTypeId { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
