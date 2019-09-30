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
    [DependencyInjection(typeof(ISnippetRepository), DependencyInjectionScope.Scoped)]
    public class SnippetRepository : RepositoryBase<Snippet, CodeSnippetsDbContext>, ISnippetRepository
    {
        public SnippetRepository(ICodeSnippetsDbContextFactory contextFactory) : base(contextFactory)
        {

        }
    }

    public class SnippetConfiguration : IEntityTypeConfiguration<Snippet>
    {
        public void Configure(EntityTypeBuilder<Snippet> builder)
        {
            builder.HasKey(snippet => snippet.Id);

            builder.Property(snippet => snippet.Name)
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(snippet => snippet.Description)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(snippet => snippet.Code)
                .HasMaxLength(2000)
                .IsRequired();

            builder.HasOne(snippet => snippet.Author)
                .WithMany(user => user.Snippets)
                .HasForeignKey(snippet => snippet.UserId)
                .IsRequired();

            builder.HasMany(snippet => snippet.SnippetTags)
                .WithOne(snippetTag => snippetTag.Snippet)
                .IsRequired();

        }
    }
}
