using System;
using System.Collections.Generic;

namespace dotNetfiy.Subscriber.EDMX
{
    public partial class Image : BaseVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public byte[] ProfileImage { get; set; } = null!;
        public bool? Active { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? ProfileThumbImageUrl { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
