using _$PROJECT_NAME$_.Database.Repositories;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.Entities.Entities.M2MMappings;
using _$PROJECT_NAME$_.Services.Interfaces;
using _$PROJECT_NAME$_.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using _$PROJECT_NAME$_.Database.Repositories.M2MMappings;
using _$PROJECT_NAME$_.Database.Repositories.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories.M2MMappings.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _$PROJECT_NAME$_.Services
{
    [DependencyInjection(typeof(ISnippetService), DependencyInjectionScope.Scoped)]
    public class SnippetService : ISnippetService
    {
        readonly IUserRepository _userRepository;
        readonly ISnippetRepository _snippetRepository;
        readonly ISnippetTagRepository _snippetTagRepository;
        readonly ILanguageRepository _languageRepository;
        readonly ITagRepository _tagReposory;
        public SnippetService(IUserRepository userRepository, ISnippetRepository snippetRepository,
            ILanguageRepository languageRepository, ITagRepository tagRepository,
            ISnippetTagRepository snippetTagRepository)
        {
            _userRepository = userRepository;
            _snippetRepository = snippetRepository;
            _languageRepository = languageRepository;
            _tagReposory = tagRepository;
            _snippetTagRepository = snippetTagRepository;
        }
        public async Task<Snippet> AddSnippet(string name, string description, string code, User author, Language language, ICollection<Tag> tags)
        {
            var snippet = new Snippet()
            {
                Name = name,
                Description = description,
                Code = code,
                Language = language,
                Author = _userRepository.GetById(author.Id)
            };

            
            snippet = await _snippetRepository.AddAsync(snippet);
            await _snippetRepository.CommitAsync();

            snippet.SnippetTags = await BindTagsToSnippet(snippet, tags);

            return snippet;
        }

        public async Task<Snippet> GetSnippetById(int id)
        {
            return await _snippetRepository.GetByIdAsync(id);
        }

        public async Task<Snippet> GetPrivateSnippet(int userId, int snippetId)
        {
            return await _snippetRepository.Query().FirstOrDefaultAsync(x => x.UserId == userId && x.Id == snippetId);
        }

        public async Task<ICollection<Tag>> GetTagsBySnippet(Snippet snippet)
        {
            return ( await _snippetRepository.Query()
                .Include(x => x.SnippetTags)
                .ThenInclude(y => y.Tag)
                .Where(z => z.Id == snippet.Id)
                .FirstAsync())
                .SnippetTags
                .Select(a=>a.Tag)
                .ToArray();
        }


        private async Task<ICollection<SnippetTag>> BindTagsToSnippet(Snippet snippet, ICollection<Tag> tags)
        {
            var snippetTags = tags.Select(tag => new SnippetTag()
            {
                Snippet = snippet,
                Tag = tag
            }).ToArray();
            await _snippetTagRepository.AddAsync(snippetTags);
            await _snippetTagRepository.CommitAsync();
            snippetTags = tags.Select(tag => _snippetTagRepository.Query().FirstOrDefault(snippetTag => snippetTag.Tag == tag)).ToArray();
            return snippetTags;
        }
    }
}
