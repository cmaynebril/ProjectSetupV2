using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceTypeId",
                table: "JobTasks",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
