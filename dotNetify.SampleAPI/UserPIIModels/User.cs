using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Images = new HashSet<Image>();
            Phones = new HashSet<Phone>();
            UserPersonaSummaries = new HashSet<UserPersonaSummary>();
            Websites = new HashSet<Website>();
        }

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? TimezoneId { get; set; }
        public int? LanguageId { get; set; }
        public string? Nickname { get; set; }
        public int? Gender { get; set; }
        public int? BirthCountryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
        public int? CountryId { get; set; }
        public DateTime? DateMasked { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<UserPersonaSummary> UserPersonaSummaries { get; set; }
        public virtual ICollection<Website> Websites { get; set; }
    }
}
