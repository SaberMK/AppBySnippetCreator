using _$PROJECT_NAME$_.Database.Base;
using _$PROJECT_NAME$_.Database.Interfaces;
using _$PROJECT_NAME$_.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Concrete
{
    public abstract class _$PROJECT_NAME$_DbRepositoryBase<TEntity> : RepositoryBase<TEntity, _$PROJECT_NAME$_DbContext>
        where TEntity : class, IEntity, new()
    {
        protected _$PROJECT_NAME$_DbRepositoryBase(IDbContextFactory<_$PROJECT_NAME$_DbContext> contextFactory) : base(contextFactory)
        {

        }
    }
}
