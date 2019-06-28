using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class invoice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_InvoiceTypeId",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "InvoiceTypeId",
                table: "JobTasks");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceType",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTypeId",
                table: "JobTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_InvoiceTypeId",
                table: "JobTasks",
                column: "InvoiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks",
                column: "InvoiceTypeId",
                principalTable: "InvoiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
