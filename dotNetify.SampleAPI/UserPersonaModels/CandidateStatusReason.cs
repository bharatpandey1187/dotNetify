using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class CandidateStatusReason
    {
        public CandidateStatusReason()
        {
            CandidateRedeployments = new HashSet<CandidateRedeployment>();
            CandidateTalentDevelopments = new HashSet<CandidateTalentDevelopment>();
            CandidateTransitions = new HashSet<CandidateTransition>();
        }

        public int Id { get; set; }
        public string Reason { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public int StatusId { get; set; }
        public bool? Active { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid? LastUpdatedByUserId { get; set; }

        public virtual CandidateStatus Status { get; set; } = null!;
        public virtual ICollection<CandidateRedeployment> CandidateRedeployments { get; set; }
        public virtual ICollection<CandidateTalentDevelopment> CandidateTalentDevelopments { get; set; }
        public virtual ICollection<CandidateTransition> CandidateTransitions { get; set; }
    }
}
