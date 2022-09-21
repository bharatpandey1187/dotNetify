using System;
using System.Collections.Generic;

namespace dotNetify.Console.EDMX
{
    public partial class UserEmailType
    {
        public UserEmailType()
        {
            Emails = new HashSet<Email>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
    }
}
