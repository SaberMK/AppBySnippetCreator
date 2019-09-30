using CodeSnippets.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Entities.Entities
{
    public class Language : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
