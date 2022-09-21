using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class UserRelationshipType
    {
        public UserRelationshipType()
        {
            UsersRelationshipMappings = new HashSet<UsersRelationshipMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<UsersRelationshipMapping> UsersRelationshipMappings { get; set; }
    }
}
