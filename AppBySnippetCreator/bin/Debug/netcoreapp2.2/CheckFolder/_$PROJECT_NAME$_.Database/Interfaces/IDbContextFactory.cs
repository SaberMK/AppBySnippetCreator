using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Interfaces
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
