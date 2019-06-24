using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class UserRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_JobTasks_Assignees_AssigneeId",
            //    table: "JobTasks");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_JobTasks_AspNetUsers_AssigneeId",
            //    table: "JobTasks",
            //    column: "AssigneeId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_AspNetUsers_AssigneeId",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Assignees_AssigneeId",
                table: "JobTasks",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
