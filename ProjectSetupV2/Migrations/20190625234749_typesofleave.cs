using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class typesofleave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfLeave",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Leave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfLeave", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_InvoiceTypeId",
                table: "Tasks",
                column: "InvoiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_InvoiceType_InvoiceTypeId",
                table: "Tasks",
                column: "InvoiceTypeId",
                principalTable: "InvoiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_InvoiceType_InvoiceTypeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TypesOfLeave");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_InvoiceTypeId",
                table: "Tasks");
        }
    }
}
