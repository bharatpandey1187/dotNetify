using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class UsersRelationshipMapping
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AssignedUserId { get; set; }
        public int RelationshipTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }

        public virtual UserRelationshipType RelationshipType { get; set; } = null!;
    }
}
