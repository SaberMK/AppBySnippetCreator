using CodeSnippets.Database.Interfaces;
using CodeSnippets.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Base
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
