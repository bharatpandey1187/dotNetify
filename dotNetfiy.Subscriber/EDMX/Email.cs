﻿using System;
using System.Collections.Generic;

namespace dotNetfiy.Subscriber.EDMX
{
    public partial class Email : BaseVM
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
    }
}