using CodeSnippets.Database.Base;
using CodeSnippets.Database.Interfaces;
using CodeSnippets.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Concrete
{
    public abstract class CodeSnippetsDbRepositoryBase<TEntity> : RepositoryBase<TEntity, CodeSnippetsDbContext>
        where TEntity : class, IEntity, new()
    {
        protected CodeSnippetsDbRepositoryBase(IDbContextFactory<CodeSnippetsDbContext> contextFactory) : base(contextFactory)
        {

        }
    }
}
