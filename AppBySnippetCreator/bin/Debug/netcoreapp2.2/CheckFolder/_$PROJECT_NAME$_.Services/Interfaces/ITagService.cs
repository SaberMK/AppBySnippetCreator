using _$PROJECT_NAME$_.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Services.Interfaces
{
    public interface ITagService
    {
        Task<ICollection<Tag>> AddOrUpdateTags(string[] tags);
    }
}
