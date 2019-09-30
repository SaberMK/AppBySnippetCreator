using _$PROJECT_NAME$_.Database.Interfaces;
using _$PROJECT_NAME$_.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Base
{
    public abstract class DbContextFactoryBase<TDbContext> : Disposable, IDbContextFactory<TDbContext>
        where TDbContext : DbContext, new()
    {
        private TDbContext _context;

        public TDbContext GetDbContext()
        {
            if (IsDisposed)
                throw new ObjectDisposedException("ContextFactory");

            return _context ?? (_context = new TDbContext());
        }

        protected override void DisposeCore()
        {
            _context?.Dispose();
        }
    }
}
