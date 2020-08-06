using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;

namespace RemoteController.Web.Hubs
{
    public class MachineHub : Hub
    {
        private static readonly HubMannager<string> Connections =
            new HubMannager<string>();

        private static readonly List<string> ReceivedResults  = new List<string>();

        private readonly IMachineService _machineService;
        private readonly IUnitOfWork _uof;

        public MachineHub(IMachineService machineService, IUnitOfWork uof)
        {
            _machineService = machineService;
            _uof = uof;
        }

        public async Task SendCommand(List<string> clients, string command)
        {
            await Clients.Users(clients).SendAsync("ExecuteCommand", command);
        }

        public void CommandResult(List<string> results)
        {
            ReceivedResults.AddRange(results);
        }

        public void SetMachine(string jsonObject)
        {
            var machineViewModel = JsonConvert.DeserializeObject<MachineViewModel>(jsonObject);
            _machineService.Add(machineViewModel);
            _uof.Commit();
        }

        public override async Task OnConnectedAsync()
        {
            Connections.Add(Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Connections.Remove(Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
