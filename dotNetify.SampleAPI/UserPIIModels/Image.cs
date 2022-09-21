using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class Image
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
