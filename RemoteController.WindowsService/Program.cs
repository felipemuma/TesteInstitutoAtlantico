using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using PeterKottas.DotNetCore.WindowsService;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependenciesRegistry.Configure();
            var powerShellWorker = ActivatorUtilities.CreateInstance<PowerShellWorker>(serviceProvider);
            ServiceRunner<Service>.Run(config => SetServiceConfigurations(config, powerShellWorker));
        }

        private static void SetServiceConfigurations(HostConfigurator<Service> config, IPowerShellWorker powerShellWorker)
        {
            const string name = "RemoteControllerClient";
            const string displayName = "Remote Controller Client";
            const string description = "Servico para permitir o controle do computador remotamente atraves de CLI";

            config.SetName(name);

            config.SetDisplayName(displayName);

            config.SetDescription(description);

            config.Service(serviceConfig =>
            {
                serviceConfig.ServiceFactory((extraArguments, microServiceController) => new Service(microServiceController, powerShellWorker));

                serviceConfig.OnStart((service, extraArguments) => { service.Start(); });

                serviceConfig.OnStop(service => { service.Stop(); });

                serviceConfig.OnInstall(service => { Console.WriteLine($"Instalando servico {name}"); });

                serviceConfig.OnUnInstall(service => { Console.WriteLine($"Desinstalando servico {name}"); });

                serviceConfig.OnPause(service => { Console.WriteLine($"Servico {name} pausado"); });

                serviceConfig.OnError(e => { Console.WriteLine($"Ocorreu um erro no servico, excessao: {e.Message}"); });
            });
        }
    }
}
