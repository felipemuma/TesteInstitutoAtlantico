using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Microsoft.Tools.ServiceModel.WsatConfig;
//using NetFwTypeLib;

namespace RemoteController.WindowsService
{
    public static class MachineInformation
    {
        public static string WindowsVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        public static string IpAddress()
        {
            var hostName = Dns.GetHostName();

            return Dns.GetHostEntry(hostName).AddressList
                .FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString();
        }

        public static string Name()
        {
            return Dns.GetHostName();
        }

        public static bool IsFirewallActive()
        {
            try
            {
                //https://docs.microsoft.com/en-us/archive/blogs/securitytools/automating-windows-firewall-settings-with-c
                //Note: In Visual Studio, you need to add NetFwTypeLib COM reference to your project and also include NetFwTypeLib in your project ( using NetFwTypeLib;)
                Type tpNetFirewall = Type.GetTypeFromProgID
                    ("HNetCfg.FwMgr", false);

                INetFirewallMgr mgrInstance = (INetFirewallMgr)Activator
                    .CreateInstance(tpNetFirewall);

                bool blnEnabled = mgrInstance.LocalPolicy
                    .CurrentProfile.FirewallEnabled;

                return blnEnabled;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
