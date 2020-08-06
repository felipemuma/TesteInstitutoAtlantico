using Microsoft.Extensions.DependencyInjection;
using RemoteController.Application.Interfaces;
using RemoteController.Application.Services;
using RemoteController.Data.Context;
using RemoteController.Data.Repository;
using RemoteController.Data.UOW;
using RemoteController.Domain.Interfaces;

namespace RemoteController.IoC
{
    public class DependencyInjectionBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IMachineService, MachineService>();

            //Data
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<RemoteControllerContext>();
        }
    }
}
