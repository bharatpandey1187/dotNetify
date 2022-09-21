using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class UserPhoneType
    {
        public UserPhoneType()
        {
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }
}
