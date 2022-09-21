using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class PersonaType
    {
        public PersonaType()
        {
            UserLegacyInfos = new HashSet<UserLegacyInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<UserLegacyInfo> UserLegacyInfos { get; set; }
    }
}
