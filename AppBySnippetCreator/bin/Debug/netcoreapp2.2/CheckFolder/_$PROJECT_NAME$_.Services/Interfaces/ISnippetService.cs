using _$PROJECT_NAME$_.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Services.Interfaces
{
    public interface ISnippetService
    {
        Task<Snippet> AddSnippet(string name, string description, string code, User author, Language language, ICollection<Tag> tags);
        Task<ICollection<Tag>> GetTagsBySnippet(Snippet snippet);
        Task<Snippet> GetSnippetById(int id);
        Task<Snippet> GetPrivateSnippet(int userId, int snippetId);
    }
}
