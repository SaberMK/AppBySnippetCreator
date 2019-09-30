using _$PROJECT_NAME$_.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Entities.Entities.M2MMappings
{
    public class SnippetTag : IEntity
    {
        public long Id { get; set; }
        public long SnippetId { get; set; }
        public Snippet Snippet { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
