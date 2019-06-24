using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class invoice1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceTypeId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks",
                column: "InvoiceTypeId",
                principalTable: "InvoiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceTypeId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_InvoiceType_InvoiceTypeId",
                table: "JobTasks",
                column: "InvoiceTypeId",
                principalTable: "InvoiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
