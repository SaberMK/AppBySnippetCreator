using CodeSnippets.Database.Repositories;
using CodeSnippets.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CodeSnippets.Database.Concrete
{
    public class CodeSnippetsDbContext : DbContext
    {
        public CodeSnippetsDbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "Data Source=WINDOWS-6HPH7SV\\SQLEXPRESS;Initial Catalog=codesnippetsdb;Integrated Security=True"; //TODO
            options.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodeSnippetsDbContext).Assembly);
        }
    }
}
