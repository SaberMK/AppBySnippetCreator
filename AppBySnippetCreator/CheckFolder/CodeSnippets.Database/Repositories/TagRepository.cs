using CodeSnippets.Database.Base;
using CodeSnippets.Database.Concrete;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Database.Repositories.Interfaces;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Repositories
{
    [DependencyInjection(typeof(ITagRepository), DependencyInjectionScope.Scoped)]
    public class TagRepository : RepositoryBase<Tag, CodeSnippetsDbContext>, ITagRepository
    {
        public TagRepository(ICodeSnippetsDbContextFactory contextFactory) : base(contextFactory)
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
