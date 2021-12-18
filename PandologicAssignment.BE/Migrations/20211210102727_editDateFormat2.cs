using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandologicAssignment.Migrations
{
    public partial class editDateFormat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ActiveJobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostDate",
                table: "ActiveJobs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT")
                .OldAnnotation("Relational:ColumnOrder", 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ActiveJobs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostDate",
                table: "ActiveJobs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date")
                .Annotation("Relational:ColumnOrder", 1);
        }
    }
}
