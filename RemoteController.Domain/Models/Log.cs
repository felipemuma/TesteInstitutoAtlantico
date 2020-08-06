using System;
using System.Collections.Generic;
using System.Text;
using RemoteController.Domain.Core.Models;

namespace RemoteController.Domain.Models
{
    public class Log : Entity
    {
        public DateTime Data { get; set; }

        public string CommandExeccuted { get; set; }

        public string Result { get; set; }

        public Machine Machine { get; set; }
    }
}
