using CodeSnippets.Database.Repositories.Interfaces;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services
{
    [DependencyInjection(typeof(ILanguageService), DependencyInjectionScope.Transient)]
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public IEnumerable<string> GetAllLanguages()
        {
            return _languageRepository.Query().Select(lang => lang.Name);
        }

        public Language GetLanguageByContent(string content)
        {
            var languages = _languageRepository.Query().Select(lang => lang.Name);
            var res =  _languageRepository.Query().SingleOrDefault(lang => lang.Name == content);
            return res;
        }

        public async Task<string> GetLanguageTextById(long id)
        {
            var lang = await _languageRepository.GetByIdAsync(id);
            return lang.Name;
        }
    }
}
