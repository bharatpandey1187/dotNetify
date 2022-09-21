using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.EDMX
{
    public partial class AlternateLanguage
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int LanguageId { get; set; }
    }
}
