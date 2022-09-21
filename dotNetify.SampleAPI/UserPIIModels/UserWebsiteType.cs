using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class UserWebsiteType
    {
        public UserWebsiteType()
        {
            Websites = new HashSet<Website>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Website> Websites { get; set; }
    }
}
