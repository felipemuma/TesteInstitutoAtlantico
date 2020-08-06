﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RemoteController.Data.Context;

namespace RemoteController.Data.Migrations
{
    [DbContext(typeof(RemoteControllerContext))]
    partial class RemoteControllerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RemoteController.Domain.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommandExeccuted");

                    b.Property<DateTime>("Data");

                    b.Property<Guid?>("MachineId")
                        .IsRequired();

                    b.Property<string>("Result");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("RemoteController.Domain.Models.Machine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("DotNetFrameworkVersion")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<double>("HdSize");

                    b.Property<string>("IpAddress")
                        .HasColumnType("varchar(39)")
                        .HasMaxLength(39);

                    b.Property<bool>("IsAntivirusActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsAvaliable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<bool>("IsFirewallActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("SpaceHdFree");

                    b.Property<string>("WindowsVersion")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Machines");

                    b.HasData(
                        new { Id = new Guid("2971099f-afa1-4284-8950-02ebc7f95822"), DotNetFrameworkVersion = "net461", HdSize = 1000000.0, IpAddress = "192.168.1.1", IsAntivirusActive = false, IsAvaliable = true, IsFirewallActive = true, Name = "PC_01", SpaceHdFree = 500000.0, WindowsVersion = "1739" },
                        new { Id = new Guid("3e55e1f7-b535-4f5d-a576-8c7b3042820e"), DotNetFrameworkVersion = "net461", HdSize = 2000000.0, IpAddress = "192.168.1.4", IsAntivirusActive = true, IsAvaliable = true, IsFirewallActive = true, Name = "PC_02", SpaceHdFree = 300000.0, WindowsVersion = "1737" },
                        new { Id = new Guid("8974eae0-53d6-4677-ba5c-5b72182ebf27"), DotNetFrameworkVersion = "net461", HdSize = 2000000.0, IpAddress = "192.168.1.8", IsAntivirusActive = true, IsAvaliable = true, IsFirewallActive = true, Name = "Note_01", SpaceHdFree = 1000000.0, WindowsVersion = "1738" },
                        new { Id = new Guid("ed56dc25-fd00-4a9d-a0fc-419bd93f5ac2"), DotNetFrameworkVersion = "net461", HdSize = 1000000.0, IpAddress = "192.168.1.10", IsAntivirusActive = false, IsAvaliable = false, IsFirewallActive = true, Name = "Note_03", SpaceHdFree = 100000.0, WindowsVersion = "1740" }
                    );
                });

            modelBuilder.Entity("RemoteController.Domain.Models.Log", b =>
                {
                    b.HasOne("RemoteController.Domain.Models.Machine", "Machine")
                        .WithMany("Logs")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
