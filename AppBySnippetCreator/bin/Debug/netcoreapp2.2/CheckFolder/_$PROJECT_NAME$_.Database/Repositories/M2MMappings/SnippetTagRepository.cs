using _$PROJECT_NAME$_.Database.Base;
using _$PROJECT_NAME$_.Database.Concrete;
using _$PROJECT_NAME$_.Database.Concrete.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories.M2MMappings.Interfaces;
using _$PROJECT_NAME$_.Entities.Entities.M2MMappings;
using _$PROJECT_NAME$_.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Repositories.M2MMappings
{
    [DependencyInjection(typeof(ISnippetTagRepository), DependencyInjectionScope.Scoped)]
    public class SnippetTagRepository : RepositoryBase<SnippetTag, _$PROJECT_NAME$_DbContext>, ISnippetTagRepository
    {
        public SnippetTagRepository(I_$PROJECT_NAME$_DbContextFactory contextFactory) : base(contextFactory)
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
