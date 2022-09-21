using System;
using System.Collections.Generic;

namespace dotNetfiy.Subscriber.EDMX
{
    public partial class UserPersonaSummary : BaseVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int PersonaTypeId { get; set; }
        public bool Active { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
