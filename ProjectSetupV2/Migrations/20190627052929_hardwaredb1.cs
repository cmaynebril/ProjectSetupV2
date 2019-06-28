using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class hardwaredb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserHardware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Disks = table.Column<int>(nullable: false),
                    Displays = table.Column<int>(nullable: false),
                    UsbDevices = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHardware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHardware_Disk_Disks",
                        column: x => x.Disks,
                        principalTable: "Disk",
                        principalColumn: "DiskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHardware_Display_Displays",
                        column: x => x.Displays,
                        principalTable: "Display",
                        principalColumn: "DisplayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHardware_UsbDevice_UsbDevices",
                        column: x => x.UsbDevices,
                        principalTable: "UsbDevice",
                        principalColumn: "DiskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHardware_Disks",
                table: "UserHardware",
                column: "Disks");

            migrationBuilder.CreateIndex(
                name: "IX_UserHardware_Displays",
                table: "UserHardware",
                column: "Displays");

            migrationBuilder.CreateIndex(
                name: "IX_UserHardware_UsbDevices",
                table: "UserHardware",
                column: "UsbDevices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHardware");
        }
    }
}
