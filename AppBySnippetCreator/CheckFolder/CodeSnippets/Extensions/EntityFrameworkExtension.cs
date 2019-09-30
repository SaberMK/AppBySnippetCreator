using CodeSnippets.Database;
using CodeSnippets.Database.Interfaces;
using CodeSnippets.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            //var connection = configuration.GetConnectionString("DefaultConnection");
            
            //services.AddDbContext<UserContext>(options =>
            //    options.UseSqlServer(connection));

        }
    }
}
