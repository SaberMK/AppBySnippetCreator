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
    [DependencyInjection(typeof(ISnippetRepository), DependencyInjectionScope.Scoped)]
    public class SnippetRepository : RepositoryBase<Snippet, _$PROJECT_NAME$_DbContext>, ISnippetRepository
    {
        public SnippetRepository(I_$PROJECT_NAME$_DbContextFactory contextFactory) : base(contextFactory)
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
