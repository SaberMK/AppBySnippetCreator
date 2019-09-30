using _$PROJECT_NAME$_.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Services.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<string> GetAllLanguages();
        Language GetLanguageByContent(string content);
        Task<string> GetLanguageTextById(long id);
    }
}
