using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.UserPersonaModels
{
    public partial class UserLanguage
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
    }
}
