using System;
using System.Collections.Generic;

namespace dotNetify.SampleAPI.Entity
{
    public  class GenderTypeEntity
    {
        public GenderTypeEntity()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameTranslationKey { get; set; }
        public bool? Active { get; set; }
    }
}
