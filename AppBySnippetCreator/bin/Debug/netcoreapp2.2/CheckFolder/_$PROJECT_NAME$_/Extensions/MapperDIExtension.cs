using AutoMapper;
using _$PROJECT_NAME$_.Mappings;
using _$PROJECT_NAME$_.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Extensions
{
    public static class MapperDIExtension
    {
        public static void AddMapperDI(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelsMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
