using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class UserPersonaSummary
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PersonaTypeId { get; set; }
        public bool Active { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
