using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class JobTasks008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_JobTasks_JobTasksId",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessValues_JobTasks_JobTasksId",
                table: "BusinessValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_JobTasks_JobTasksId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTasks_JobTasksId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_JobTasks_JobTasksId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_JobTasksId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobTasksId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Clients_JobTasksId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_BusinessValues_JobTasksId",
                table: "BusinessValues");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_JobTasksId",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "JobTasksId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "JobTasksId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobTasksId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "JobTasksId",
                table: "BusinessValues");

            migrationBuilder.DropColumn(
                name: "JobTasksId",
                table: "Assignees");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "Tasks",
                nullable: true);

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

            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "BusinessValues",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "Assignees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_JobTasksId",
                table: "Tasks",
                column: "JobTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTasksId",
                table: "Jobs",
                column: "JobTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_JobTasksId",
                table: "Clients",
                column: "JobTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessValues_JobTasksId",
                table: "BusinessValues",
                column: "JobTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_JobTasksId",
                table: "Assignees",
                column: "JobTasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_JobTasks_JobTasksId",
                table: "Assignees",
                column: "JobTasksId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessValues_JobTasks_JobTasksId",
                table: "BusinessValues",
                column: "JobTasksId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_JobTasks_JobTasksId",
                table: "Clients",
                column: "JobTasksId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTasks_JobTasksId",
                table: "Jobs",
                column: "JobTasksId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_JobTasks_JobTasksId",
                table: "Tasks",
                column: "JobTasksId",
                principalTable: "JobTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
