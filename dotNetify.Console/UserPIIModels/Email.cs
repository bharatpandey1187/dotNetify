using System;
using System.Collections.Generic;

namespace dotNetify.Console.EDMX
{
    public partial class Email
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UserEmailTypeId { get; set; }
        public string Value { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual UserEmailType UserEmailType { get; set; } = null!;
    }
}
