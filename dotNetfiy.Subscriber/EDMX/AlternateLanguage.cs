using System;
using System.Collections.Generic;

namespace dotNetfiy.Subscriber.EDMX
{
    public partial class AlternateLanguage : BaseVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int LanguageId { get; set; }
    }
}
