using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.Entity
{
    public  class UserPersonaSummaryEntity
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PersonaTypeId { get; set; }
        public bool Active { get; set; }
    }
}
