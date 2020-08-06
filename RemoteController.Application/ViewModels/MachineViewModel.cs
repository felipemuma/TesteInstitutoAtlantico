using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RemoteController.Application.ViewModels
{
    public class MachineViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome da Máquina")]
        public string Name { get; set; }

        [DisplayName("Ip Local")]
        public string IpAddress { get; set; }

        [DisplayName("Antivirus Instalado")]
        public bool IsAntivirusActive { get; set; }

        [DisplayName("Firewall Ativo")]
        public bool IsFirewallActive { get; set; }

        [DisplayName("Versão do Windows")]
        public string WindowsVersion { get; set; }

        [DisplayName("Versão do .NET Framework")]
        public string DotNetFrameworkVersion { get; set; }

        [DisplayName("Espaço HD Dsiponível")]
        public double SpaceHdFree{ get; set; }

        [DisplayName("Espaço HD Total")]
        public double HdSize { get; set; }

        [DisplayName("PC Ligado")]
        public bool IsAvaliable { get; set; }
    }
}
