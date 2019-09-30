using CodeSnippets.Entities.Entities.M2MMappings;
using CodeSnippets.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Entities.Entities
{
    public class Tag : IEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public ICollection<SnippetTag> SnippetTags { get; set; }
    }
}
