using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.Migrations
{
    public partial class renamedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StudentSubjectses_Students_StudentId",
                "StudentSubjectses");

            migrationBuilder.DropForeignKey(
                "FK_StudentSubjectses_Subjects_SubjectId",
                "StudentSubjectses");

            migrationBuilder.DropPrimaryKey(
                "PK_StudentSubjectses",
                "StudentSubjectses");

            migrationBuilder.RenameTable(
                "StudentSubjectses",
                newName: "StudentSubjects");

            migrationBuilder.RenameIndex(
                "IX_StudentSubjectses_SubjectId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_SubjectId");

            migrationBuilder.RenameIndex(
                "IX_StudentSubjectses_StudentId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_StudentId");

            migrationBuilder.AddPrimaryKey(
                "PK_StudentSubjects",
                "StudentSubjects",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StudentSubjects_Students_StudentId",
                "StudentSubjects",
                "StudentId",
                "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_StudentSubjects_Subjects_SubjectId",
                "StudentSubjects",
                "SubjectId",
                "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_StudentSubjects_Students_StudentId",
                "StudentSubjects");

            migrationBuilder.DropForeignKey(
                "FK_StudentSubjects_Subjects_SubjectId",
                "StudentSubjects");

            migrationBuilder.DropPrimaryKey(
                "PK_StudentSubjects",
                "StudentSubjects");

            migrationBuilder.RenameTable(
                "StudentSubjects",
                newName: "StudentSubjectses");

            migrationBuilder.RenameIndex(
                "IX_StudentSubjects_SubjectId",
                table: "StudentSubjectses",
                newName: "IX_StudentSubjectses_SubjectId");

            migrationBuilder.RenameIndex(
                "IX_StudentSubjects_StudentId",
                table: "StudentSubjectses",
                newName: "IX_StudentSubjectses_StudentId");

            migrationBuilder.AddPrimaryKey(
                "PK_StudentSubjectses",
                "StudentSubjectses",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_StudentSubjectses_Students_StudentId",
                "StudentSubjectses",
                "StudentId",
                "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_StudentSubjectses_Subjects_SubjectId",
                "StudentSubjectses",
                "SubjectId",
                "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}