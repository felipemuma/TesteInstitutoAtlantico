using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;

namespace RemoteController.WindowsService
{
    public sealed class Service : MicroService, IMicroService
    {
        private readonly IMicroServiceController _microServiceController;
        private readonly IPowerShellWorker _powerShellWorker;
        private static HubConnection _hubConnection;

        public Service(IMicroServiceController microServiceController ,IPowerShellWorker powerShellWorker)
        {
            _microServiceController = microServiceController;
            _powerShellWorker = powerShellWorker;
        }

        public void Start()
        {
            StartBase();

            Task.Run(async () =>
            {
                await ConnectToServer();

                MachineViewModel machineViewModel = new MachineViewModel
                {
                    Name = MachineInformation.Name(),
                    IpAddress = MachineInformation.IpAddress(),
                    WindowsVersion = MachineInformation.WindowsVersion(),
                    IsFirewallActive = MachineInformation.IsFirewallActive()
                };

                var jsonObject = JsonConvert.SerializeObject(machineViewModel);

                await _hubConnection.InvokeAsync("SetMachine", jsonObject);

                Timers.Start("ReadCommands", 200, () =>
                {
                    if (_powerShellWorker.OutputResult.Any())
                    {
                        _hubConnection.InvokeAsync("CommandResult", _powerShellWorker.OutputResult);
                        _powerShellWorker.OutputResult.Clear();
                    }
                });
            });

            _powerShellWorker.ReadOutput();
        }

        public void Stop()
        {
            Task.Run(async () => await _hubConnection.DisposeAsync());

            StopBase();
        }

        public static async Task ConnectToServer()
        {
            var baseUrl = "http://localhost:61481/hub";

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(baseUrl)
                .Build();

            await _hubConnection.StartAsync();
        }
    }
}
