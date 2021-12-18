using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandologicAssignment.Migrations
{
    public partial class editDateJobView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ViewDate",
                table: "JobViews",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ViewDate",
                table: "JobViews",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
