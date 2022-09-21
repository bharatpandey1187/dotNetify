using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class Colleague
    {
        public int Id { get; set; }
        public int? OfficeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public Guid? LastUpdatedByUserId { get; set; }
        public bool? Active { get; set; }
    }
}
