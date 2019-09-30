using _$PROJECT_NAME$_.Database.Base;
using _$PROJECT_NAME$_.Database.Concrete;
using _$PROJECT_NAME$_.Database.Concrete.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories.Interfaces;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Repositories
{
    [DependencyInjection(typeof(ITagRepository), DependencyInjectionScope.Scoped)]
    public class TagRepository : RepositoryBase<Tag, _$PROJECT_NAME$_DbContext>, ITagRepository
    {
        public TagRepository(I_$PROJECT_NAME$_DbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(tag => tag.Id);

            builder.Property(tag => tag.Content)
                .HasMaxLength(50);

            builder.HasMany(tag => tag.SnippetTags)
                .WithOne(snippetTag => snippetTag.Tag)
                .IsRequired();
        }
    }
}
