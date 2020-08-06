using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace RemoteController.Web.Extensions
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            Application.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}
