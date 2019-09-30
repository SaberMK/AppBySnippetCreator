using CodeSnippets.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Concrete.Interfaces
{
    public interface ICodeSnippetsDbContextFactory : IDbContextFactory<CodeSnippetsDbContext>
    {
    }
}
