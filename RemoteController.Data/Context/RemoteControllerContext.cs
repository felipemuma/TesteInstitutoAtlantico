using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RemoteController.Data.Mappings;
using RemoteController.Domain.Models;

namespace RemoteController.Data.Context
{
    public class RemoteControllerContext : DbContext
    {
        public RemoteControllerContext(DbContextOptions<RemoteControllerContext> options) :base(options) { }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MachineMap());

            modelBuilder.Entity<Log>()
                .HasOne(l => l.Machine)
                .WithMany(m => m.Logs)
                .IsRequired();

            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = Guid.NewGuid(), Name = "PC_01", IpAddress = "192.168.1.1", IsAntivirusActive = false, IsFirewallActive = true, WindowsVersion = "1739", DotNetFrameworkVersion = "net461", SpaceHdFree = 500000, HdSize = 1000000, IsAvaliable = true },
                new Machine { Id = Guid.NewGuid(), Name = "PC_02", IpAddress = "192.168.1.4", IsAntivirusActive = true, IsFirewallActive = true, WindowsVersion = "1737", DotNetFrameworkVersion = "net461", SpaceHdFree = 300000, HdSize = 2000000, IsAvaliable = true },
                new Machine { Id = Guid.NewGuid(), Name = "Note_01", IpAddress = "192.168.1.8", IsAntivirusActive = true, IsFirewallActive = true, WindowsVersion = "1738", DotNetFrameworkVersion = "net461", SpaceHdFree = 1000000, HdSize = 2000000, IsAvaliable = true },
                new Machine { Id = Guid.NewGuid(), Name = "Note_03", IpAddress = "192.168.1.10", IsAntivirusActive = false, IsFirewallActive = true, WindowsVersion = "1740", DotNetFrameworkVersion = "net461", SpaceHdFree = 100000, HdSize = 1000000, IsAvaliable = false }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
