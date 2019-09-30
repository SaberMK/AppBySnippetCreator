using _$PROJECT_NAME$_.Entities.Entities.M2MMappings;
using _$PROJECT_NAME$_.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Entities.Entities
{
    public class Snippet : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public long UserId { get; set; }
        public User Author { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<SnippetTag> SnippetTags { get; set; }
    }
}
