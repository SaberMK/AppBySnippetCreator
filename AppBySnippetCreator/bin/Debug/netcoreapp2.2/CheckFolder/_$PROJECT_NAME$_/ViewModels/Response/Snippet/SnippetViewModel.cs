using _$PROJECT_NAME$_.ViewModels.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.ViewModels.Response.Snippet
{
    public class SnippetViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string[] Tags { get; set; } 
        public AuthorViewModel Author { get; set; }
    }
}
