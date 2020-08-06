using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RemoteController.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IpAddress = table.Column<string>(type: "varchar(39)", maxLength: 39, nullable: true),
                    IsAntivirusActive = table.Column<bool>(nullable: false, defaultValue: false),
                    IsFirewallActive = table.Column<bool>(nullable: false, defaultValue: false),
                    WindowsVersion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DotNetFrameworkVersion = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    SpaceHdFree = table.Column<double>(nullable: false),
                    HdSize = table.Column<double>(nullable: false),
                    IsAvaliable = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    CommandExeccuted = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true),
                    MachineId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "DotNetFrameworkVersion", "HdSize", "IpAddress", "IsAntivirusActive", "IsAvaliable", "IsFirewallActive", "Name", "SpaceHdFree", "WindowsVersion" },
                values: new object[,]
                {
                    { new Guid("2971099f-afa1-4284-8950-02ebc7f95822"), "net461", 1000000.0, "192.168.1.1", false, true, true, "PC_01", 500000.0, "1739" },
                    { new Guid("3e55e1f7-b535-4f5d-a576-8c7b3042820e"), "net461", 2000000.0, "192.168.1.4", true, true, true, "PC_02", 300000.0, "1737" },
                    { new Guid("8974eae0-53d6-4677-ba5c-5b72182ebf27"), "net461", 2000000.0, "192.168.1.8", true, true, true, "Note_01", 1000000.0, "1738" },
                    { new Guid("ed56dc25-fd00-4a9d-a0fc-419bd93f5ac2"), "net461", 1000000.0, "192.168.1.10", false, false, true, "Note_03", 100000.0, "1740" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_MachineId",
                table: "Logs",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
