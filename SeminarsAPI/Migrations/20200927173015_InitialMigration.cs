using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarsAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeminarModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Speaker = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    MaxAttendees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    SeminarID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AttendeeModels_SeminarModels_SeminarID",
                        column: x => x.SeminarID,
                        principalTable: "SeminarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeModels_SeminarID",
                table: "AttendeeModels",
                column: "SeminarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeModels");

            migrationBuilder.DropTable(
                name: "SeminarModels");
        }
    }
}
