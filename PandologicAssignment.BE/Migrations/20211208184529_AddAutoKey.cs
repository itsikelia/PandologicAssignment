using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandologicAssignment.Migrations
{
    public partial class AddAutoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobViews",
                table: "JobViews");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobViews",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ViewId",
                table: "JobViews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobViews",
                table: "JobViews",
                column: "ViewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobViews",
                table: "JobViews");

            migrationBuilder.DropColumn(
                name: "ViewId",
                table: "JobViews");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobViews",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobViews",
                table: "JobViews",
                column: "JobId");
        }
    }
}
