using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class contactPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Clients");
        }
    }
}
