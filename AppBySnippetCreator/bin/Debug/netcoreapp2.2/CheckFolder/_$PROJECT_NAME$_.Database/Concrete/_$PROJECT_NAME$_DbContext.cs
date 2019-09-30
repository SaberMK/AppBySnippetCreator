using _$PROJECT_NAME$_.Database.Repositories;
using _$PROJECT_NAME$_.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace _$PROJECT_NAME$_.Database.Concrete
{
    public class _$PROJECT_NAME$_DbContext : DbContext
    {
        public _$PROJECT_NAME$_DbContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connection = "Data Source=WINDOWS-6HPH7SV\\SQLEXPRESS;Initial Catalog=codesnippetsdb;Integrated Security=True"; //TODO
            options.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(_$PROJECT_NAME$_DbContext).Assembly);
        }
    }
}
