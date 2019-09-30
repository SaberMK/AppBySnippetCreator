using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.ViewModels.Request.Snippet
{
    public class AddSnippetViewModel : TokenViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public string[] Tags { get; set; }
    }
}
