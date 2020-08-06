using System.Collections;
using System.Collections.Generic;
using RemoteController.Domain.Core.Models;

namespace RemoteController.Domain.Models
{
    public class Machine : Entity
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public bool IsAntivirusActive { get; set; }
        public bool IsFirewallActive { get; set; }
        public string WindowsVersion { get; set; }
        public string DotNetFrameworkVersion { get; set; }
        public double SpaceHdFree{ get; set; }
        public double HdSize { get; set; }
        public bool IsAvaliable { get; set; }

        public ICollection<Log> Logs { get; set; }
    }
}
