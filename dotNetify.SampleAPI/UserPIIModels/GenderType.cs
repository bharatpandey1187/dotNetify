using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class GenderTypeEntity
    {
        public GenderTypeEntity()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
