using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class JobTasks002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Assignees_AssigneeId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_BusinessValues_BusinessValueId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Clients_ClientId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Tasks_TaskId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_AssigneeId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_BusinessValueId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_ClientId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_TaskId",
                table: "JobTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusinessValueId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "JobTasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TaskId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "JobId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "BusinessValueId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "JobTasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_AssigneeId",
                table: "JobTasks",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_BusinessValueId",
                table: "JobTasks",
                column: "BusinessValueId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_ClientId",
                table: "JobTasks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_TaskId",
                table: "JobTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Assignees_AssigneeId",
                table: "JobTasks",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_BusinessValues_BusinessValueId",
                table: "JobTasks",
                column: "BusinessValueId",
                principalTable: "BusinessValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Clients_ClientId",
                table: "JobTasks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Jobs_JobId",
                table: "JobTasks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Tasks_TaskId",
                table: "JobTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
