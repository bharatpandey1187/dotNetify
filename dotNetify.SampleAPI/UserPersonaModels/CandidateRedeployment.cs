using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class CandidateRedeployment
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int EmployeeGroupId { get; set; }
        public int ProgramId { get; set; }
        public int ContractId { get; set; }
        public string? EmployeeId { get; set; }
        public int StatusReasonId { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedByUserId { get; set; }
        public Guid CompanyId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? ProgramCompletionDate { get; set; }
        public DateTime? CountryExpirationDate { get; set; }
        public DateTime? ResumeExpirationDate { get; set; }
        public DateTime? GracePeriodEndDate { get; set; }

        public virtual CandidateStatusReason StatusReason { get; set; } = null!;
    }
}
