using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class CandidateStatus
    {
        public CandidateStatus()
        {
            CandidateStatusReasons = new HashSet<CandidateStatusReason>();
        }

        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid? LastUpdatedByUserId { get; set; }
        public int? CategoryId { get; set; }

        public virtual ICollection<CandidateStatusReason> CandidateStatusReasons { get; set; }
    }
}
