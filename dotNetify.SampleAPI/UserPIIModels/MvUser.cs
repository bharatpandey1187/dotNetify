using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class MvUser
    {
        public long? RowCount { get; set; }
        public Guid? Id { get; set; }
        public string? Nickname { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int? PersonaTypeId { get; set; }
        public string? ProjectName { get; set; }
        public int? CompanyId { get; set; }
        public int? CountryId { get; set; }
        public int? TimezoneId { get; set; }
        public int? Gender { get; set; }
        public int? LanguageId { get; set; }
        public int? UserPhoneTypeId { get; set; }
        public string? Phone { get; set; }
        public int? UserEmailTypeId { get; set; }
        public string? Email { get; set; }
        public int? StatusReasonId { get; set; }
    }
}
