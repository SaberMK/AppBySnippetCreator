using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Interfaces
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
