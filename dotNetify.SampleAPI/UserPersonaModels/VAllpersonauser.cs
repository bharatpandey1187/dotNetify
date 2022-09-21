using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class VAllpersonauser
    {
        public Guid? UserId { get; set; }
        public int? StatusReasonId { get; set; }
        public int? PersonaTypeId { get; set; }
        public int? ContractId { get; set; }
        public string? ProjectName { get; set; }
    }
}
