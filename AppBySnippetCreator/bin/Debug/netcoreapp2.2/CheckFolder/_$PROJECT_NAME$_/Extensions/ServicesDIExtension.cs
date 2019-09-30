using AutoMapper;
using _$PROJECT_NAME$_.Database;
using _$PROJECT_NAME$_.Database.Concrete;
using _$PROJECT_NAME$_.Database.Concrete.Interfaces;
using _$PROJECT_NAME$_.Database.Interfaces;
using _$PROJECT_NAME$_.Database.Repositories;
using _$PROJECT_NAME$_.Database.Repositories.Interfaces;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.Services;
using _$PROJECT_NAME$_.Services.Interfaces;
using _$PROJECT_NAME$_.Utils;
using _$PROJECT_NAME$_.Utils.Interfaces;
using _$PROJECT_NAME$_.Utils.ResponseCreators;
using _$PROJECT_NAME$_.Utils.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Extensions
{
    public static class ServicesDIExtension
    {
        public static void AddServicesDI (this IServiceCollection services)
        {
            AddContexts(services);
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            var typesFromRepositories = DependencyInjectionAttribute.GetBindingForAssembly(typeof(_$PROJECT_NAME$_DbContext).Assembly).ToList();
            var typesFromServices = DependencyInjectionAttribute.GetBindingForAssembly(typeof(BaseServiceObject).Assembly);

            AddServicesFromDIAttribute(typesFromServices, services);
            AddServicesFromDIAttribute(typesFromRepositories, services);


            //TEST
            int a = 0;
            //END TESTS
        }

        private static void AddServicesFromDIAttribute(IEnumerable<DependencyInjectionBinding> bindings, IServiceCollection services)
        {
            bindings.ToList().ForEach(x =>
            {
                switch (x.Scope)
                {
                    case DependencyInjectionScope.Scoped:
                        {
                            services.AddScoped(x.Source, x.Destination);
                            break;
                        }
                    case DependencyInjectionScope.Singleton:
                        {
                            services.AddSingleton(x.Source, x.Destination);
                            break;
                        }
                    case DependencyInjectionScope.Transient:
                        {
                            services.AddTransient(x.Source, x.Destination);
                            break;
                        }
                }
            });
        }

        private static void AddContexts(IServiceCollection services)
        {
            services.AddScoped<I_$PROJECT_NAME$_DbContextFactory, _$PROJECT_NAME$_DbContextFactory>();
            services.AddSingleton<IUserPasswordEncoder, UserPasswordDoubleBase64Encoder>();
            services.AddSingleton<IResponseCreator, ResponseCreator>();
            services.AddSingleton<IUserTokenCreator>(s => new UserTokenHMACCreator("☺☺☺"));
        }
    }
}
