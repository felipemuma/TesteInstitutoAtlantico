using System;
using System.ComponentModel.DataAnnotations;

namespace RemoteController.Application.ViewModels
{
    public class LogViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public string CommandExeccuted { get; set; }

        public string Result { get; set; }

        public MachineViewModel Machine { get; set; }
    }
}
