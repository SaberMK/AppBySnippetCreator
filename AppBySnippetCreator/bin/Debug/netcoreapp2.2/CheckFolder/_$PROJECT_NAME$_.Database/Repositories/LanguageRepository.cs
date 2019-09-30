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
    [DependencyInjection(typeof(ILanguageRepository), DependencyInjectionScope.Scoped)]
    public class LanguageRepository : RepositoryBase<Language, _$PROJECT_NAME$_DbContext>, ILanguageRepository
    {
        public LanguageRepository(I_$PROJECT_NAME$_DbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(language => language.Id);

            builder.Property(language => language.Name)
                .HasMaxLength(30);

        }
    }
}
