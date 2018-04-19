using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class PartedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "Name",
                "Students",
                "Lastname");

            migrationBuilder.AddColumn<string>(
                "Firstname",
                "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Firstname",
                "Students");

            migrationBuilder.RenameColumn(
                "Lastname",
                "Students",
                "Name");
        }
    }
}