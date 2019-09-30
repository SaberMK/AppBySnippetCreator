using CodeSnippets.Database.Base;
using CodeSnippets.Database.Concrete;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Database.Repositories.M2MMappings.Interfaces;
using CodeSnippets.Entities.Entities.M2MMappings;
using CodeSnippets.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Repositories.M2MMappings
{
    [DependencyInjection(typeof(ISnippetTagRepository), DependencyInjectionScope.Scoped)]
    public class SnippetTagRepository : RepositoryBase<SnippetTag, CodeSnippetsDbContext>, ISnippetTagRepository
    {
        public SnippetTagRepository(ICodeSnippetsDbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }


    public class SnippetTagConfiguration : IEntityTypeConfiguration<SnippetTag>
    {
        public void Configure(EntityTypeBuilder<SnippetTag> builder)
        {
            builder.HasKey(snippetTag => snippetTag.Id);

            builder.HasOne(snippetTag => snippetTag.Snippet)
                .WithMany(snippet => snippet.SnippetTags)
                .HasForeignKey(snippetTag => snippetTag.SnippetId)
                .IsRequired();

            builder.HasOne(snippetTag => snippetTag.Tag)
                .WithMany(tag => tag.SnippetTags)
                .HasForeignKey(snippetTag => snippetTag.TagId)
                .IsRequired();
        }
    }
}
