using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class hardwaredb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHardware_Disk_Disks",
                table: "UserHardware");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHardware_Display_Displays",
                table: "UserHardware");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHardware_UsbDevice_UsbDevices",
                table: "UserHardware");

            migrationBuilder.DropIndex(
                name: "IX_UserHardware_Disks",
                table: "UserHardware");

            migrationBuilder.DropIndex(
                name: "IX_UserHardware_Displays",
                table: "UserHardware");

            migrationBuilder.DropIndex(
                name: "IX_UserHardware_UsbDevices",
                table: "UserHardware");

            migrationBuilder.DropColumn(
                name: "Disks",
                table: "UserHardware");

            migrationBuilder.DropColumn(
                name: "Displays",
                table: "UserHardware");

            migrationBuilder.DropColumn(
                name: "UsbDevices",
                table: "UserHardware");

            migrationBuilder.RenameColumn(
                name: "DiskId",
                table: "UsbDevice",
                newName: "UsbDeviceId");

            migrationBuilder.AddColumn<int>(
                name: "UserHardwareId",
                table: "UsbDevice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserHardwareId",
                table: "Display",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserHardwareId",
                table: "Disk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsbDevice_UserHardwareId",
                table: "UsbDevice",
                column: "UserHardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Display_UserHardwareId",
                table: "Display",
                column: "UserHardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Disk_UserHardwareId",
                table: "Disk",
                column: "UserHardwareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_UserHardware_UserHardwareId",
                table: "Disk",
                column: "UserHardwareId",
                principalTable: "UserHardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Display_UserHardware_UserHardwareId",
                table: "Display",
                column: "UserHardwareId",
                principalTable: "UserHardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsbDevice_UserHardware_UserHardwareId",
                table: "UsbDevice",
                column: "UserHardwareId",
                principalTable: "UserHardware",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_UserHardware_UserHardwareId",
                table: "Disk");

            migrationBuilder.DropForeignKey(
                name: "FK_Display_UserHardware_UserHardwareId",
                table: "Display");

            migrationBuilder.DropForeignKey(
                name: "FK_UsbDevice_UserHardware_UserHardwareId",
                table: "UsbDevice");

            migrationBuilder.DropIndex(
                name: "IX_UsbDevice_UserHardwareId",
                table: "UsbDevice");

            migrationBuilder.DropIndex(
                name: "IX_Display_UserHardwareId",
                table: "Display");

            migrationBuilder.DropIndex(
                name: "IX_Disk_UserHardwareId",
                table: "Disk");

            migrationBuilder.DropColumn(
                name: "UserHardwareId",
                table: "UsbDevice");

            migrationBuilder.DropColumn(
                name: "UserHardwareId",
                table: "Display");

            migrationBuilder.DropColumn(
                name: "UserHardwareId",
                table: "Disk");

            migrationBuilder.RenameColumn(
                name: "UsbDeviceId",
                table: "UsbDevice",
                newName: "DiskId");

            migrationBuilder.AddColumn<int>(
                name: "Disks",
                table: "UserHardware",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Displays",
                table: "UserHardware",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsbDevices",
                table: "UserHardware",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserHardware_Disk_Disks",
                table: "UserHardware",
                column: "Disks",
                principalTable: "Disk",
                principalColumn: "DiskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHardware_Display_Displays",
                table: "UserHardware",
                column: "Displays",
                principalTable: "Display",
                principalColumn: "DisplayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHardware_UsbDevice_UsbDevices",
                table: "UserHardware",
                column: "UsbDevices",
                principalTable: "UsbDevice",
                principalColumn: "DiskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
