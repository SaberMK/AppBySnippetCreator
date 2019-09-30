using CodeSnippets.Database.Base;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Database.Concrete
{
    public class CodeSnippetsDbContextFactory : DbContextFactoryBase<CodeSnippetsDbContext>, ICodeSnippetsDbContextFactory
    {
    }
}
