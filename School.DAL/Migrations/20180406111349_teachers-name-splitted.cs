using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class teachersnamesplitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "Name",
                "Teachers",
                "Lastname");

            migrationBuilder.AddColumn<string>(
                "Firstname",
                "Teachers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Firstname",
                "Teachers");

            migrationBuilder.RenameColumn(
                "Lastname",
                "Teachers",
                "Name");
        }
    }
}