using _$PROJECT_NAME$_.Database.Repositories;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.Services.Interfaces;
using _$PROJECT_NAME$_.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using _$PROJECT_NAME$_.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _$PROJECT_NAME$_.Services
{
    [DependencyInjection(typeof(ITagService), DependencyInjectionScope.Scoped)]
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<ICollection<Tag>> AddOrUpdateTags(string[] tags)
        {
            var tagEntities = new List<Tag>();

            foreach(var tag in tags)
            {
                var tagEntity = await _tagRepository.Query().FirstOrDefaultAsync(x => x.Content == tag);
                if (tagEntity == null)
                {
                    tagEntity = await _tagRepository.AddAsync(new Tag()
                    {
                        Content = tag
                    });
                }
            }

            await _tagRepository.CommitAsync();
            tagEntities = tags.Select(x => _tagRepository.Query().FirstOrDefault(y=>y.Content==x)).ToList();
            return tagEntities;
        }
    }
}
