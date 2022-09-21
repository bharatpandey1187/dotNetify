using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class UserLegacyInfo
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PersonaTypeId { get; set; }
        public string? AlternateContact { get; set; }
        public int? OpportunityId { get; set; }
        public int? ReferralId { get; set; }
        public bool? RedeploymentContract { get; set; }
        public bool? RedeploymentProgram { get; set; }

        public virtual PersonaType PersonaType { get; set; } = null!;
    }
}
