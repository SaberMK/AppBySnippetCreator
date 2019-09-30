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
    [DependencyInjection(typeof(IUserRepository), DependencyInjectionScope.Scoped)]
    public class UserRepository : RepositoryBase<User, _$PROJECT_NAME$_DbContext>, IUserRepository
    {
        public UserRepository(I_$PROJECT_NAME$_DbContextFactory contextFactory) : base(contextFactory)
        {
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(user => user.Password)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(user => user.AccessLevel)
                .HasDefaultValue(AccessLevel.USER)
                .IsRequired();

            builder.HasMany(user => user.Snippets)
                .WithOne(snippet => snippet.Author)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
