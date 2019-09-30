using CodeSnippets.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Interfaces
{
    public interface ITagService
    {
        Task<ICollection<Tag>> AddOrUpdateTags(string[] tags);
    }
}
