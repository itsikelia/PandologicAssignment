using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandologicAssignment.Migrations
{
    public partial class UpdateDbLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobViews",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ViewDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobViews", x => x.JobId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobViews");
        }
    }
}
