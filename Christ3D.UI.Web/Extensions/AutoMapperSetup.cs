using AutoMapper;
using Christ3D.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Christ3D.UI.Web.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) 
            { 
                throw new ArgumentNullException(nameof(services)); 
            }
            services.AddAutoMapper(Assembly.Load("Christ3D.Application"));
            AutoMapperConfig.RegisterMappings();
        }
    }
}
