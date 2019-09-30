using CodeSnippets.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<string> GetAllLanguages();
        Language GetLanguageByContent(string content);
        Task<string> GetLanguageTextById(long id);
    }
}
