﻿using System;
using System.Collections.Generic;

namespace dotNetfiy.Subscriber.EDMX
{
    public partial class Phone
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UserPhoneTypeId { get; set; }
        public string Value { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
