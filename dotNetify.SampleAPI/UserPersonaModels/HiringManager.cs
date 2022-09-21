using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class HiringManager
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? ContractId { get; set; }
        public Guid CompanyId { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid LastUpdatedByUserId { get; set; }
    }
}
