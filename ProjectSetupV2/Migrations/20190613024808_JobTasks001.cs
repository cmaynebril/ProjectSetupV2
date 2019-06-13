using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class JobTasks001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "JobTasksId",
                table: "Tasks",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimeSpent = table.Column<double>(nullable: false),
                    TaskId = table.Column<long>(nullable: true),
                    JobId = table.Column<long>(nullable: true),
                    ClientId = table.Column<long>(nullable: true),
                    BusinessValueId = table.Column<long>(nullable: true),
                    AssigneeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTasks_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_BusinessValues_BusinessValueId",
                        column: x => x.BusinessValueId,
                        principalTable: "BusinessValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "JobTasks");

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
        }
    }
}
