using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.Entity
{
    public class EmailEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UserEmailTypeId { get; set; }
        public string Value { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }
    }
}
