using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class invoice3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTypeId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTypeId",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceType",
                table: "Tasks",
                nullable: true);
        }
    }
}
