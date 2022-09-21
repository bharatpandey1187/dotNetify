namespace dotNetify.SampleAPI.Entity
{
    public class UserEntity
    {
        public UserEntity()
        {
            Addresses = new List<AddressEntity>();
            Emails = new List<EmailEntity>();
            Phones = new List<PhoneEntity>();
            UserPersonaSummaries = new List<UserPersonaSummaryEntity>();
            WebSites = new List<WebsiteEntity>();
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

        public virtual List<AddressEntity> Addresses { get; set; }
        public virtual List<EmailEntity> Emails { get; set; }
        public virtual List<PhoneEntity> Phones { get; set; }
        public virtual List<UserPersonaSummaryEntity> UserPersonaSummaries { get; set; }
        public virtual List<WebsiteEntity> WebSites { get; set; }
    }
}
