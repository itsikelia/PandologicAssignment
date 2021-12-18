using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandologicAssignment.Migrations
{
    public partial class AddActiveJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveJobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveJobs", x => new { x.JobId, x.PostDate });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveJobs");
        }
    }
}
