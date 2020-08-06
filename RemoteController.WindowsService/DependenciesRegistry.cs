using Microsoft.Extensions.DependencyInjection;
using PeterKottas.DotNetCore.WindowsService;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    internal static class DependenciesRegistry
    {        
        public static ServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IPowerShellWorker, PowerShellWorker>();
            services.AddSingleton<IMicroServiceController, MicroServiceController>();
            var serviceProveider = services.BuildServiceProvider();
            return serviceProveider;
        }
    }
}
