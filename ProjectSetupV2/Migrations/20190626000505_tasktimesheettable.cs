using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class tasktimesheettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Task",
                table: "TaskTimesheet",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Job",
                table: "TaskTimesheet",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TaskTimesheet",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Client",
                table: "TaskTimesheet",
                newName: "Billable");

            migrationBuilder.AlterColumn<double>(
                name: "TotalTimeSpent",
                table: "TaskTimesheet",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessValueId",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "TaskTimesheet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskTimesheet_AssigneeId",
                table: "TaskTimesheet",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTimesheet_BusinessValueId",
                table: "TaskTimesheet",
                column: "BusinessValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTimesheet_ClientId",
                table: "TaskTimesheet",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTimesheet_JobId",
                table: "TaskTimesheet",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTimesheet_TaskId",
                table: "TaskTimesheet",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimesheet_AspNetUsers_AssigneeId",
                table: "TaskTimesheet",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimesheet_BusinessValues_BusinessValueId",
                table: "TaskTimesheet",
                column: "BusinessValueId",
                principalTable: "BusinessValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimesheet_Clients_ClientId",
                table: "TaskTimesheet",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimesheet_Jobs_JobId",
                table: "TaskTimesheet",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTimesheet_Tasks_TaskId",
                table: "TaskTimesheet",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimesheet_AspNetUsers_AssigneeId",
                table: "TaskTimesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimesheet_BusinessValues_BusinessValueId",
                table: "TaskTimesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimesheet_Clients_ClientId",
                table: "TaskTimesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimesheet_Jobs_JobId",
                table: "TaskTimesheet");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTimesheet_Tasks_TaskId",
                table: "TaskTimesheet");

            migrationBuilder.DropIndex(
                name: "IX_TaskTimesheet_AssigneeId",
                table: "TaskTimesheet");

            migrationBuilder.DropIndex(
                name: "IX_TaskTimesheet_BusinessValueId",
                table: "TaskTimesheet");

            migrationBuilder.DropIndex(
                name: "IX_TaskTimesheet_ClientId",
                table: "TaskTimesheet");

            migrationBuilder.DropIndex(
                name: "IX_TaskTimesheet_JobId",
                table: "TaskTimesheet");

            migrationBuilder.DropIndex(
                name: "IX_TaskTimesheet_TaskId",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "BusinessValueId",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TaskTimesheet");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TaskTimesheet");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TaskTimesheet",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TaskTimesheet",
                newName: "Job");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "TaskTimesheet",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Billable",
                table: "TaskTimesheet",
                newName: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "TotalTimeSpent",
                table: "TaskTimesheet",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
