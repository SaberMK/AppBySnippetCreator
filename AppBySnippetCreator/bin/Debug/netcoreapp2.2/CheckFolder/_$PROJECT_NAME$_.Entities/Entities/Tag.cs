using _$PROJECT_NAME$_.Entities.Entities.M2MMappings;
using _$PROJECT_NAME$_.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Entities.Entities
{
    public class Tag : IEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public ICollection<SnippetTag> SnippetTags { get; set; }
    }
}
