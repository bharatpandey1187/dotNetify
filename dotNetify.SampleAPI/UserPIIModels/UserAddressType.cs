using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class UserAddressType
    {
        public UserAddressType()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
