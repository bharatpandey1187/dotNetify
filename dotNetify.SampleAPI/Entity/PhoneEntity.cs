using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.Entity
{
    public partial class PhoneEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UserPhoneTypeId { get; set; }
        public string Value { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
    }
}
