using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSetupV2.Migrations
{
    public partial class UserSoftware1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSoftware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningSoftwares",
                columns: table => new
                {
                    SoftwareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateInstalled = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    MainSoftwareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningSoftwares", x => x.SoftwareId);
                    table.ForeignKey(
                        name: "FK_RunningSoftwares_UserSoftware_MainSoftwareId",
                        column: x => x.MainSoftwareId,
                        principalTable: "UserSoftware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunningSoftwares_MainSoftwareId",
                table: "RunningSoftwares",
                column: "MainSoftwareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunningSoftwares");

            migrationBuilder.DropTable(
                name: "UserSoftware");
        }
    }
}
